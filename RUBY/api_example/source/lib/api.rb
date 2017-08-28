module Api
    require 'sinatra'
    require_relative './../models/crayon'

    class CrayonApi < Sinatra::Base
        @crayons = Array.new

        get '/' do
            "Welcome to the Crayons API"
        end

        # View all
        get '/crayons' do
            msg = "Viewing all crayons"
            msg += @crayons.to_s
            msg
        end

        # Get specific
        get '/crayons/:id' do
            msg = "Viewing crayon of id " + (params[:id]).to_s
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