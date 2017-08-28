module Api
    require 'sinatra'
    require_relative './../models/crayon'

    include Model

    class CrayonApi < Sinatra::Base
        #crayons = []
        
        set :crayons, Array.new
        

        get '/' do
            "Welcome to the Crayons API"
        end

        # View all
        get '/crayons' do
            msg = "Viewing all crayons: "
            settings.crayons.each do |crayon|
                msg << " " + crayon.color.to_s + " "
            end
            msg
        end

        # Get specific
        get '/crayons/:id' do
            msg = "Viewing crayon of id " + (params[:id]).to_s

            found = false
            settings.crayons.each do |crayon|
                if (found == false && crayon.color.to_s == params[:id].to_s)
                    msg = msg + " | Found."
                    found = true
                end
            end

            if !found
                settings.crayons.push(Crayon.new(params[:id].to_s))
                msg = msg + " | Not found, so inserted."
            end
            
            msg
        end

        # Create one
        post '/crayons' do
            status 201
            "Created a crayon"
        end

        # Update specific
        put '/crayons/:id' do
            status 202
            "Updated a crayon"
        end

        # Delete specific
        delete '/crayons/:id' do
            status 202
            "Deleted " + (params[:id]).to_s
        end
    end
    
end