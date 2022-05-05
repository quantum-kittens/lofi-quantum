from microqiskit import QuantumCircuit, simulate

# MicroQiskit: https://github.com/qiskit-community/MicroQiskit

# build quantum circuit and measure
qc = QuantumCircuit(2,2)
qc.h(0)
qc.cx(0,1)
qc.measure(0,0)
qc.measure(1,1)
counts = simulate(qc,shots=1000,get='counts')

# fetch the answer and derive the cat's state
cat_state = {'00': 'asleep', '11': 'awake'}
ans = str(max(counts, key=counts.get))
print(counts)
print(" ")
print('The cat is ' + cat_state[ans])
