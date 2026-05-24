# Space Tracer

**Space Tracer** is a fast-paced, mobile arcade survival game built in Unity. Players pilot a spacecraft through waves of enemies surviving an escalating difficulty curve to chase the ultimate high score. Developed independently, the game was fully published and maintained on the Google Play Store, it was my first game release serving as a key project in mastering mobile development and gameplay loops.

---

## Features

*   **Endless Survival Gameplay:** Endless waves of enemies spawn with increasing difficulty over time. As long as the player's health does not reach 0 the enemies will spawn in waves.
*   **Waypoint-Driven Wave System:** Dynamically handles enemy behaviors and flight paths utilizing a robust waypoint-based node network.
*   **Data-Driven Wave Generation:** Powered by **ScriptableObjects** to define enemy configurations, spawn rates, and movement patterns independently of execution logic.
*   **Mobile-Optimized Input:** Smooth,touch-and-drag controls tailored specifically for casual mobile play.
*   **Data Persistence & Google Play Games Integration:** Local high-score tracking linked to Google Play Games high score leaderboards to incentivize replayability and player engagement.
*   **Performance-First Architecture:** Lightweight 2D rendering and optimized collisions ensuring a consistent, high-framerate experience across a wide range of Android devices.

---

## Built With

*   **Engine:** Unity
*   **Language:** C#
*   **Architecture:** Data-Driven (Scriptable objects) & Modular design
*   **Target Platforms:** Android (Google Play Store), WEBGL(itch.io)

---

## About the Project & Key Takeaways

Space Tracer was designed to bridge the gap between core arcade mechanics and production-ready mobile optimization. Shipping this project independently provided comprehensive experience across the entire development lifecycle:
*   **Waypoint-Driven Wave System:** Dynamically handles enemy behaviors and flight paths utilizing a robust waypoint-based node network and scriptable objects to configure the waves.
*   **Gameplay Engineering:** Architecting responsive movement for the player ship, automating gameobject spawns, and rigorous testing of 2D collision/trigger matrices. Implementing features such as power-ups to help diversify gameplay.
*   **Mobile UI/UX Layouts:** Designing canvas-driven user interfaces that scale fluidly across various mobile aspect ratios without breaking layout anchors.
*   **Release & Distribution:** Navigating the Google Play Console deployment pipeline and testing, asset bundling, and version control management.

---

## What I Learned

This project advanced my capabilities as a game developer and designer, specifically in:
*   **Data/Logic Separation:** Understanding the power of ScriptableObjects in Unity to create highly scalable, configuration-based gameplay systems.
*   **Mobile input handling:** Learning Unity's input system and touch controls.
*   **Micro-Balancing & Game Feel:** Learning how subtle adjustments to player movement, hitboxes, and bonuses such as power-ups exponentially increase player satisfaction and replay value.
*   **Production Discipline:** As this was my first game release the biggest impact was gaining the problem-solving autonomy required to take a raw concept through prototyping, debugging, polishing, and a live public release.

---

## Future Improvements

While the core survival loop is in place, potential future expansions include:
*   **Data-Driven Customization:** Integrating a ScriptableObject-driven customisation system for unlockable ship variants and cosmetic trails. Which I later went on to do in my next game Duck Dive.
*   **Visual Overhaul:** Implementing advanced 2D particle systems, dynamic lighting, and post-processing effects.

---

## Developer

**George Brackpool**  
An indie game developer and software engineer with a background spanning full-stack development and interactive 3D applications. My current technical focus centers on space-themed programming applications, real-time rendering, telemetry visualization, and robust API integrations.

---

## 🔗 Links

*   [Google Play Store Storefront](#) *(https://play.google.com/store/apps/details?id=com.GBrackpool.SpaceTracer&hl=en_GB)*
*   [Portfolio Website](#) *(https://georgebrackpool.github.io/Portfolio-George-Brackpool/)*
*   [GitHub Profile](#) *(https://github.com/GeorgeBrackpool)*
