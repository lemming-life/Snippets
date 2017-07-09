// Author: http://lemming.life
// Language: C++
// Title: T-Intersection
/* Challenge Description:
    Write C++ code for a controller for a stop light at a T-Intersection according to
    the following rules. The straight part of the intersection runs East-West and receives the heaviest
    traffic and should be green most often. The intersecting road runs North and only receives light
    traffic and therefore contains a single sensor to inform the light of the presence of a car.
    If the sensor is activated for more than 10 seconds the light for the East/Westbound commuters
    should turn yellow for 3 seconds, then red. 2 seconds later the light for Northbound commuters
    should turn green. If the sensor goes inactive for more than 5 seconds the light will then cycle
    back to be green for East/West bound commuters. Additionally, the Northbound light will never be
    green for longer than 40 seconds and the East/Westbound lights will never be green for less than 30s.
    Your controller should contain an UpdateController() function that will be called once per second.
*/

/* Notes:
    - This program was coded on Mac OS X Sierra, using Visual Studio Code.
    - To compile at terminal: g++ intersection.cpp
    - To run at terminal: ./a.out
    - There is an example simulation in the driver (main function).
    - The simulation can be changed by changing the state of a sensor and
      -- by advancing the time by x amount of seconds.
    - Messages are displayed and can be disabled.
    - Message format: (time stamp) | (message)
*/

#include <iostream>
#include <vector>
#include <string>
using namespace std;

// Enums
enum Color { Green, Yellow, Red };
enum Operation { LessThanEqual, GreaterThan };

// A Time Singleton.
// - We could also have implemented it as an object and then pass it as needed.
class Time {
private:
    static Time* instance;
    int currentTime;
    Time() { currentTime = 0; }
public:
    static Time* getInstance() {
        return instance != NULL ? instance : (instance = new Time());
    }

    static void update() { ++(getInstance()->currentTime); }
    static int getCurrentTime() { return getInstance()->currentTime; }
};
Time* Time::instance = NULL;


// Message Singleton to enable/disable console output.
class Messages {
private:
    static Messages* instance;
    bool enabled;
    Messages() { enabled = false; }
public:
    static Messages* getInstance() {
        return instance != NULL ? instance : (instance = new Messages());
    }

    static void turnOff() { getInstance()->enabled = false; }
    static void turnOn() { getInstance()->enabled = true; }
    static bool areEnabled() { return getInstance()->enabled; }
};
Messages* Messages::instance = NULL;


// An object that will clean up any Singletons.
class CleanUp {
public:
    ~CleanUp() {
        delete Time::getInstance();
        delete Messages::getInstance();
    }
};


// Contains data for events for Light objects.
struct Event {
public:
    int triggerTime;
    Color colorToAssign;

    Event(int triggerTime, Color colorToAssign) {
        this->triggerTime = triggerTime;
        this->colorToAssign = colorToAssign;
    }
};


// Containts constraint data and check for Light objects.
class Constraint {
public:
    int color;
    int timeAmount;
    Operation operation;

    // The constraint passed should focus on
    // - The color in which the light should be at.
    // - The time amount in seconds.
    // - The operation desired to be true.
    // Example 1:
    // -- "Light x should never be green for less than N seconds"
    // -- Translates to: Constraint(Green, N, GreaterThan)
    // Example 2:
    // -- "Light x should never be green for longer than N seconds"
    // -- Transates to: Constraint(Green, N, LessThanEqual)
    Constraint(Color color, int timeAmount, Operation operation) {
        this->color = color;
        this->timeAmount = timeAmount;
        this->operation = operation;
    }

    bool isWithin(Color lightColor, int lightTimeCount) {
        if (color != lightColor) return true;

        bool result = false;
        switch (operation) {
            case LessThanEqual:
                if (lightTimeCount <= timeAmount) { result = true; }
                break;
            case GreaterThan:
                if (lightTimeCount > timeAmount) { result = true; }
                break;
            default:
                result = false;
                break;
        }
        
        return result;
    }
};


class Light {
public:
    Light(string id, Color color, Constraint* constraint) {
        this->id = id;
        timeCount = 1;
        this->constraint = constraint;
        setColor(color);
    }

    ~Light() {
        events.clear();
        delete constraint;
    }

    bool isWithinConstraint() {
        return constraint->isWithin(color, timeCount);
    }
    
    bool isReady() {
        if (isWithinConstraint()) {
            return events.size() == 0;
        }
        return false;
    } 

    Color getColor() {
        return color;
    }

    void setColor(Color color) {
        this->color = color;
        if (color == constraint->color) { timeCount = 1; }

        if (Messages::areEnabled()) {
            cout << Time::getCurrentTime() << " | Light " << id << " changed to ";
            switch (color) {
                case Red:
                    cout << "red";      break;
                case Green:
                    cout << "green";    break;
                case Yellow:
                    cout << "yellow";   break;
                default:                break;
            }
            cout << ".\n";
        }
    }

    void addEvent(Event event) {
        events.push_back(event);
    }

    void clearEvents() {
        events.clear();
        timeCount = 1;
    }

    void update() {
        // Apply events if needed.
        for (vector<Event>::iterator iter = events.begin(); iter != events.end(); ) {
            if (iter->triggerTime == Time::getCurrentTime()) {
                setColor(iter->colorToAssign);
                iter = events.erase(iter);
            } else {
                ++iter;
            }
        }
        // Keep a count to be used with constraint checks.
        if (color == constraint->color) { ++timeCount; }
    }
    
private:
    string id;
    Color color;
    int timeCount;
    vector<Event> events;
    Constraint* constraint;
};


// The activate() and deactivate() methods must be called by the user
// - the controller only checks for the state of the sensor, and updates its timeCount.
class Sensor {
public:
    Sensor() { deactivate(); }   // DRY 
    void update() { ++timeCount; }
    bool isActive() { return state; }
    int getTimeCount() { return timeCount; }
    
    void activate() {
        state = true;
        timeCount = 1;
        if (Messages::areEnabled()) { cout << Time::getCurrentTime() << " | Sensor activated.\n"; }
    }

    void deactivate() {
        state = false;
        timeCount = 1;
        if (Messages::areEnabled()) { cout << Time::getCurrentTime() << " | Sensor deactivated.\n"; }
    }

private:
    bool state;
    int timeCount;
};

// Imagine a world where many controllers exist
// - an Interface makes sense, then one can have multiple implementations
// - suited for various scenarios.
class Controller {
public:
    virtual void UpdateController() {};
};

// The implementation.
class TController : public Controller {
public:
    TController(Sensor* sensor, Light* lightArms, Light* lightBody) {
        this->sensor = sensor;
        this->lightArms = lightArms;
        this->lightBody = lightBody;
        bodyActive = false;
    }

    void UpdateController() {

        // Neither light is ready for any sensory activation.
        // - A light could be handling events, or has failed a time constraint.
        if (!lightBody->isReady() || !lightArms->isReady()) {
            if (!lightBody->isWithinConstraint()) {
                forceChangeLightColor(lightArms, lightBody);

                if (Messages::areEnabled()) {
                    cout << Time::getCurrentTime()
                    << " | N light has been on longer than constraint."
                    << " Forcing change WE light to green, N light to red.\n";
                }
            }
        } else if(lightBody->isReady() && lightArms->isReady()) {
            // Both lights ready for sensory input.

            if (sensor->isActive()) {
                // When a vehicle is at the sensor, and time specified occurs,
                // - Switch N light to to be green, and WE light to be red.
                if (sensor->getTimeCount() > TIME_ACTIVE_AMOUNT) {
                    if (lightArms->getColor() == Green && lightBody->getColor() == Red) {
                        beginChangeLightColor(lightBody, lightArms);
                        if (Messages::areEnabled()) { cout << Time::getCurrentTime() << " | Begin changing N light to green, WE light to red.\n"; }
                    }
                }
            } else {
                // When the N has been inactive for the specified time, switch colors.
                if (sensor->getTimeCount() > TIME_INACTIVE_AMOUNT) {
                    if (lightArms->getColor() == Red && lightBody->getColor() == Green) {
                        beginChangeLightColor(lightArms, lightBody);
                        if (Messages::areEnabled()) { cout << Time::getCurrentTime() << " | Begin changing WE light to green, N light to red.\n"; }
                    }
                }
            }
        }

        sensor->update();
        lightArms->update();
        lightBody->update();
        Time::update(); // If we had more Controller implementations then this is not the place for Time::ipdate()
    }

private:
    Sensor* sensor;
    Light* lightArms;
    Light* lightBody;
    bool bodyActive;
    static int TIME_ACTIVE_AMOUNT;
    static int TIME_INACTIVE_AMOUNT;

    // Called when a light has failed a constraint.
    void forceChangeLightColor(Light* lightToGreen, Light* lightToRed) {
        lightToGreen->clearEvents();
        lightToRed->clearEvents();
        beginChangeLightColor(lightToGreen, lightToRed);
    }

    // Allows us to schedule events for the specified light.
    void beginChangeLightColor(Light* lightToGreen, Light* lightToRed) {
        lightToRed->addEvent( Event(Time::getCurrentTime(), Yellow) );
        lightToRed->addEvent( Event(Time::getCurrentTime() + 3, Red) );
        lightToGreen->addEvent( Event(Time::getCurrentTime() + 5, Green) );
    }
};
int TController::TIME_ACTIVE_AMOUNT = 10;
int TController::TIME_INACTIVE_AMOUNT = 5;


// The class helps us run our simulation.
class Scene {
public:
    Scene(Controller* controller) {
        this->controller = controller;
    }

    void advanceBy(int seconds) {
        int secondsElapsed = 0;
        while(secondsElapsed < seconds) {
            controller->UpdateController();
            // Time::update(); // If we had multiple controllers this would be an ideal spot for time updating.
            ++secondsElapsed;
        }
    }

    
    // For real seconds, we do something like this:
    /*
    // Add this to the includes section
    #include <time.h>

    // Use this function similaly to advanceBy() method.
    void advanceRealBy(int seconds) {
        int secondsElapsed = 0;
        clock_t t1, t2;

        t1 = clock();
        while (secondsElapsed < seconds) {
            t2 = clock();
            if (t2 - t1 > CLOCKS_PER_SEC) {
                controller->UpdateController();
                // Time::update(); // If we had multiple controllers
                t1 = clock();
                ++secondsElapsed;
            }
        }
    }
    // But the advanceBy() is just a faster simulation.
    */
private:
    Controller* controller;
};


// Driver
int main() {
    Messages::turnOn(); // Comment out to disable all cout messages.

    // Setup T-Intersection
    Sensor* sensor = new Sensor();
    Light* lightArms = new Light("WE", Green, new Constraint(Green, 30, GreaterThan)); // WE never less than 30
    Light* lightBody = new Light("N", Red, new Constraint(Green, 40, LessThanEqual)); // N never longer than 40
    Controller* tController = new TController(sensor, lightArms, lightBody); // Program to an interface

    // Run a simulation
    Scene scene(tController);
    scene.advanceBy(30);
    sensor->activate();
    scene.advanceBy(15);
    sensor->deactivate();
    scene.advanceBy(100);
    sensor->activate();
    scene.advanceBy(100);
    sensor->deactivate();
    scene.advanceBy(50);

    // Deadlocate memory
    delete lightBody;
    delete lightArms;
    delete sensor;
    delete tController;

    CleanUp clean; // Gets rid of Singletons when out of scope.
    return 0;
}