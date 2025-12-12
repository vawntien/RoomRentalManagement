from fastapi import FastAPI
from pydantic import BaseModel
import joblib
import pandas as pd

app = FastAPI()

# Load model
model = joblib.load("rent_price_model.pkl")

# Body yêu cầu
class RentInput(BaseModel):
    Area: float
    Location: int
    HasFurniture: int
    HasAirConditioner: int
    MaxPeople: int
    Type: str

@app.post("/predict-rent")
def predict_rent(data: RentInput):
    # Chuyển input thành DataFrame
    df = pd.DataFrame([{
        "Area": data.Area,
        "Location": data.Location,
        "HasFurniture": data.HasFurniture,
        "HasAirConditioner": data.HasAirConditioner,
        "MaxPeople": data.MaxPeople,
        "Type": data.Type
    }])

    # Dự đoán
    price = model.predict(df)[0]

    # Trả về JSON
    return {"suggested_price": float(price)}

#uvicorn api:app --reload
