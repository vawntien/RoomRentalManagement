import pandas as pd

df = pd.read_csv("phase1_rooms_cleaned.csv")

print(df.shape)
print(df.columns)
df.head()