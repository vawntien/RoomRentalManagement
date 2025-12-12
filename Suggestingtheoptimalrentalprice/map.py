# import matplotlib.pyplot as plt

# fig, ax = plt.subplots(figsize=(10, 6))
# ax.axis('off')

# steps = [
#     "Input Data\n(Area, Location, Type...)",
#     "Preprocessing\n(OneHotEncoder)",
#     "Linear Regression Model",
#     "Predicted Price",
#     "FastAPI",
#     "WinForm Display"
# ]

# y = list(range(len(steps)))[::-1]

# for i, step in enumerate(steps):
#     ax.text(0.5, y[i], step, ha='center', va='center', bbox=dict(boxstyle="round"))

# plt.show()
import networkx as nx
import matplotlib.pyplot as plt

G = nx.DiGraph()

G.add_edges_from([
    ("Input Data", "Preprocessing"),
    ("Preprocessing", "OneHotEncoder"),
    ("OneHotEncoder", "Linear Regression"),
    ("Linear Regression", "Predict Price"),
    ("Predict Price", "API"),
    ("API", "WinForm")
])

plt.figure(figsize=(10,6))
nx.draw(G, with_labels=True, node_size=3000, node_color="lightblue")
plt.show()
