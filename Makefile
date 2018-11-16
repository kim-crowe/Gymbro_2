build-run:
	docker build -t gymbro ./Gymbro.Api
	docker run -d -p 5000:80 gymbro
	#docker run -d -p 5432:5432 -e POSTGRES_PASSWORD=admin postgres:9.6