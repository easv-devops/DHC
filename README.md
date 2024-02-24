## CALCULATOR APP FOR DEVOPS

## DATABASE SCHEMA

````
CREATE TABLE calculations
(
id SERIAL PRIMARY KEY,
n1 DOUBLE PRECISION NOT NULL,
n2 DOUBLE PRECISION NOT NULL,
operation CHAR(1) NOT NULL,
result DOUBLE PRECISION NOT NULL,
calculated_at TIMESTAMP NOT NULL DEFAULT NOW()
);
````

## CONNECTION STRING

docker-compose.yml requires a connection string, this application has been designed with use of elephantSQL in mind. Therefore, Utilities.cs may need to be altered if a different source is used.

## DOCKER-COMPOSE

As this application is built with the idea of being a console based calculator, docker-compose is not great for that. In order to use the calculator as intended, the command 

`````docker-compose run mycalculator`````

instead of the normal usage, being docker-compose up

## App in a container
navigate to the app directory in the console and input
````docker build -t calculator .````

- -t option is used to tage the image 
- . instructs docker to user the file in the current directory. 
Next run:

````docker run -it -e "pgconn={YOUR CONNECTION STRING} --name calc calculator````

A breakdown of this command:
- -it is for running the container in interactive mode
- -e is setting environment variables
- --name {container name} {image name}


## App without docker

This application can also be used without docker. Navigate to the app directory and set your connection string with the command

```` export pgconn={YOUR CONNECTION STRING HERE} ````

and

````dotnet run````
in the console and it will work there as well!

## ENJOY THE MATH!