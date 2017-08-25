module StopWatch
    # Modules cannot be instantiated

    attr_accessor :seconds, :running

    def start_stop_watch
        self.seconds = 0        # Must refer to self
        self.running = true
        # would need some thread to run doing self.seconds += 1
    end

    def stop_stop_watch
        self.running = false
    end

    def resume_stop_watch
        self.running = true
    end

    def reset_stop_watch
        self.seconds = 0
        self.runnig = false
    end

    def output_stop_watch
        puts "Stop watch time: " + self.seconds.to_s
    end
end

