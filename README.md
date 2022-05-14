# Quantum Grove: A Lo-fi Ambience

## Description
Welcome to Kvantti Kunj, where playful critters scamper about lush terrain, and a qubit controls what you see…

Quantum Grove is an interactive art piece playable in the browser that functions as a lo-fi ambience for study, work, and relaxation. 

# Play the game here: [https://quantum-kittens.itch.io/quantum-grove](https://quantum-kittens.itch.io/quantum-grove)

<img src="https://github.com/quantum-kittens/lofi-quantum/blob/main/Assets/Graphics/Screenshots/Screenshot1.png" width="50%"  />

## How to Play
The player controls the audio and visuals of the ambience through buttons on the car dashboard.

### Music Controls:
 
Select between two music genres, Chill and Calm. The default genre is Calm. To control the music press Play, Pause, or Next.

### Visual Controls:
 
The state of a single qubit governs what is seen on screen. 
There are five quantum gate buttons, located on the car’s dashboard: S, St, T, Tt, and Z.
 
How to control the color of the Northern Lights:
The gates apply rotations to the qubit’s phase, which in turn inform corresponding shifts in the colors of the Northern Lights.
 
The phase controls are as follows:
S gate applies a +pi/2 rotation
St gate applies a -pi/2 rotation
T gate applies a +pi/4 rotation
Tt gate applies a -pi/4 rotation
Z gate applies a pi rotation


How to control the state of the cat:

The cat can either be awake or asleep. You can potentially change its state by clicking directly on the cat. Every time you click on the cat, the qubit is ‘measured’ and the cat’s state represents the outcome you may get while measuring the qubit: asleep represents an outcome of 0, and awake represents an outcome of 1.

Note: The qubit is always in an equally weighted superposition, as the quantum gates only affect its phase. This superposition is visually represented at the start of the game, by showing the two possible cat states:

This means there’s a 0.5 probability that the cat will either be awake or asleep after you click it. Therefore clicking on the cat doesn’t act as a simple toggle!


## How is this related to quantum?

The state of a qubit governs the visuals on screen. The state of the qubit appears in the car’s display, and the user can apply quantum gates to manipulate its state as described in the How to Play section above. The state of the cat represents the outcome you may get while measuring the qubit: asleep represents an outcome of 0, and awake represents an outcome of 1.

By playing around with the gates, players can begin to foster an intuition about how quantum gates affect qubit states, more precisely, the extent of rotations associated with each gate.

The quantum system that governs Quantum Grove was programmed using MicroQiskit.

The educational aspect of Quantum Grove was inspired by James Weaver’s Grok the Bloch sphere: https://javafxpert.github.io/grok-bloch/



## Tools
Unity 2021.3.1f1, Watercolors & ink pens, Procreate, Adobe Photoshop, Canva, Github, MicroQiskit

Github repo: https://github.com/quantum-kittens/lofi-quantum


## Credits
Ella Toppari (Illustration & Scene Design, Music)
Radha Pyari Sandhir (Digital Art & Scene Design, Unity, Quantum Physics, Music)
Marcel Pfaffhauser (Unity, Quantum Physics)
Tuure Saloheimo (Unity)

Music tracks and licences here: https://github.com/quantum-kittens/lofi-quantum/blob/main/Assets/Music/Music_licenses.md

Loading icon asset: Sphere by Lluisa Iborra from NounProject.com

Quantum Grove was made during Aalto University’s spring 2022 Quantum Games course.



