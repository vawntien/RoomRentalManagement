import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import OneHotEncoder
from sklearn.compose import ColumnTransformer
from sklearn.pipeline import Pipeline
from sklearn.linear_model import LinearRegression
import joblib

# Load data
df = pd.read_csv("room_rent_data.csv")

X = df[["Area", "Location", "HasFurniture", "HasAirConditioner", "MaxPeople", "Type"]]
y = df["Price"]

# Encoding cột phân loại
preprocess = ColumnTransformer([
    ("cat", OneHotEncoder(), ["Location", "Type"])
], remainder="passthrough")

model = Pipeline([
    ("preprocess", preprocess),
    ("regressor", LinearRegression())
])

# Train
model.fit(X, y)

# Save model
joblib.dump(model, "rent_price_model.pkl")

print("Model saved!")



