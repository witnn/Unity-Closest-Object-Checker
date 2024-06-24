## Unity Closest Object Detection

This Unity script detects the closest object within a specified area (zone) based on a given tag.
It is useful for detecting the closest enemy character to the player character in a game.

### Features
* Detects and keeps track of objects entering and exiting the zone.
* Continuously identifies and logs the closest object within the zone.
* Customizable through the Unity Inspector.

### How to Use
1. Set up the Detection Zone:
   * Create an empty GameObject in your Unity scene.
   * Attach a collider component (SphereCollider) to the GameObject.
   * Set the collider's `IsTrigger` property to true.
   * Attach the `AIZone` script to the GameObject.
2. Configure the Detection Zone:
    * In the Unity Inspector, set the `Target Tag` field to the tag of the objects you want to detect (e.g., `Enemy`, `Item`).
3. Add Objects with the Specified Tag:
    * Ensure that the objects you want to detect have the specified tag set in their Tag property.

### Example
![image](https://github.com/alisahanyalcin/Unity-Closest-Object-Detection/assets/34830846/af71a003-8f71-46b9-aa89-81f0bf65f6ab)

![Ekran görüntüsü 2024-06-24 005806](https://github.com/witnn/Unity-Closest-Object-Checker/assets/75940903/181997a7-5665-422a-bfa9-9e17d149e9ce)

