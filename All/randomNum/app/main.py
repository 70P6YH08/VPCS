from fastapi import FastAPI
import random

app = FastAPI()

@app.get("/random
def get_random_number():
    number = random.randint(1, 100)
    return {"random_number": number}