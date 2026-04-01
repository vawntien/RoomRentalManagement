import pandas as pd
import joblib

from sklearn.pipeline import Pipeline
from sklearn.compose import ColumnTransformer
from sklearn.preprocessing import OneHotEncoder
from sklearn.ensemble import RandomForestRegressor

# 1. Load dữ liệu
df = pd.read_csv("room_rent_data.csv")

X = df[[
    "Area",
    "Location",
    "HasFurniture",
    "HasAirConditioner",
    "MaxPeople",
    "Type"
]]

y = df["Price"]

# 2. Tiền xử lý
preprocessor = ColumnTransformer(
    transformers=[
        ("type", OneHotEncoder(handle_unknown="ignore"), ["Type"])
    ],
    remainder="passthrough"
)

# 3. Random Forest model
model = Pipeline(steps=[
    ("preprocess", preprocessor),
    ("regression", RandomForestRegressor(
        n_estimators=200,
        random_state=42
    ))
])

# 4. Train model
model.fit(X, y)

# 5. Lưu model
joblib.dump(model, "rent_price_model.pkl")

print("✅ Train RandomForest xong – đã lưu rent_price_model.pkl")
