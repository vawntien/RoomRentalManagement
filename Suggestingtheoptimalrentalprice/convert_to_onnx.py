import joblib
from skl2onnx import convert_sklearn
from skl2onnx.common.data_types import FloatTensorType

model = joblib.load("rent_price_model.pkl")

# input size: 6 features → shape (None, 6)
initial_type = [('input', FloatTensorType([None, 6]))]

onnx_model = convert_sklearn(model, initial_types=initial_type)

with open("rent_price_model.onnx", "wb") as f:
    f.write(onnx_model.SerializeToString())

print("🎉 Model ONNX đã được tạo!")
