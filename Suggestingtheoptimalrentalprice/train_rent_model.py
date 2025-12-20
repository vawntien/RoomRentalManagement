# # import pandas as pd
# # import joblib

# # from sklearn.pipeline import Pipeline
# # from sklearn.compose import ColumnTransformer
# # from sklearn.preprocessing import OneHotEncoder
# # from sklearn.linear_model import LinearRegression

# # # 1. Load dữ liệu
# # df = pd.read_csv("room_rent_data.csv")

# # X = df[[
# #     "Area",
# #     "Location",
# #     "HasFurniture",
# #     "HasAirConditioner",
# #     "MaxPeople",
# #     "Type"
# # ]]

# # y = df["Price"]

# # # 2. Tiền xử lý dữ liệu
# # preprocessor = ColumnTransformer(
# #     transformers=[
# #         ("type_encoder", OneHotEncoder(handle_unknown="ignore"), ["Type"])
# #     ],
# #     remainder="passthrough"
# # )

# # # 3. Tạo pipeline
# # model = Pipeline(steps=[
# #     ("preprocessing", preprocessor),
# #     ("regression", LinearRegression())
# # ])

# # # 4. Train model
# # model.fit(X, y)

# # # 5. Lưu model
# # joblib.dump(model, "rent_price_model.pkl")

# # print("✅ Train xong! Đã tạo file rent_price_model.pkl")

# import pandas as pd
# import joblib
# from sklearn.pipeline import Pipeline
# from sklearn.compose import ColumnTransformer
# from sklearn.preprocessing import OneHotEncoder, StandardScaler
# from sklearn.linear_model import LinearRegression

# df = pd.read_csv("room_rent_data.csv")

# X = df[[
#     "Area",
#     "Location",
#     "HasFurniture",
#     "HasAirConditioner",
#     "MaxPeople",
#     "Type"
# ]]

# y = df["Price"]

# preprocessor = ColumnTransformer(
#     transformers=[
#         ("type", OneHotEncoder(handle_unknown="ignore"), ["Type"])
#     ],
#     remainder="passthrough"
# )

# # model = Pipeline(steps=[
# #     ("preprocess", preprocessor),
# #     ("scaler", StandardScaler()),
# #     ("regression", LinearRegression())
# # ])

# model = Pipeline(steps=[
#     ("preprocess", preprocessor),
#     ("regression", RandomForestRegressor(n_estimators=100))
# ])

# model.fit(X, y)
# joblib.dump(model, "rent_price_model.pkl")

# print("✅ Train xong, đã fix hiện tượng diện tích ngược")

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
