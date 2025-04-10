import pandas as pd
import matplotlib.pyplot as plt

# Load the node resource usage data
csv_file = "node_resource_usage.csv"  # Make sure this matches the file from your other script
df = pd.read_csv(csv_file)

# Convert the "Date" column to datetime format
df["Date"] = pd.to_datetime(df["Date"])

# Clean and convert CPU% from string like "45%" to float
df["CPU%"] = df["CPU%"].str.replace('%', '', regex=False).astype(float)

# Create the plot
plt.figure(figsize=(12, 6))
for node in df["Node"].unique():
    node_data = df[df["Node"] == node]
    plt.plot(node_data["Date"], node_data["CPU%"], label=node)

# Format the graph
plt.title("Node CPU Usage Over Time")
plt.xlabel("Time")
plt.ylabel("CPU Usage (%)")
plt.xticks(rotation=45)
plt.grid(True)
plt.legend(title="Node")
plt.tight_layout()

# Show the graph
plt.show()

# Load the HPA dataset
csv_file = "hpa_status.csv"  # Make sure this file exists
df = pd.read_csv(csv_file)

# Convert Date to datetime
df["Date"] = pd.to_datetime(df["Date"])

# Clean CPU_Usage (remove % and convert to float)
df["CPU_Usage"] = df["CPU_Usage"].astype(str).str.replace('%', '', regex=False)
df["CPU_Usage"] = pd.to_numeric(df["CPU_Usage"], errors='coerce')

# === Plot 1: CPU Usage per Deployment ===
plt.figure(figsize=(12, 6))
for deployment in df["Deployment"].unique():
    subset = df[df["Deployment"] == deployment]
    plt.plot(subset["Date"], subset["CPU_Usage"], label=deployment)

plt.title("CPU Usage Over Time per Deployment")
plt.xlabel("Time")
plt.ylabel("CPU Usage (%)")
plt.xticks(rotation=45)
plt.grid(True)
plt.legend(title="Deployment", loc="upper left")
plt.tight_layout()
plt.show()

# === Plot 2: Replica Count per Deployment ===
plt.figure(figsize=(12, 6))
for deployment in df["Deployment"].unique():
    subset = df[df["Deployment"] == deployment]
    plt.plot(subset["Date"], subset["Replicas"], label=deployment)

plt.title("Replica Count Over Time per Deployment")
plt.xlabel("Time")
plt.ylabel("Replica Count")
plt.xticks(rotation=45)
plt.grid(True)
plt.legend(title="Deployment", loc="upper left")
plt.tight_layout()
plt.show()
