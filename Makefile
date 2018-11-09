build-run:
	docker build -t gymbro ./Gymbro.Api
	docker run -d -p 5000:80 gymbro