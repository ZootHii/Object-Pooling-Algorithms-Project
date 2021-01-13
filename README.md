# Object Pooling
 Desing And Analysis of Algorithms Project - Object Pooling method with Unity
 
 **We wrote this code by communicating with each other on discord.**<br/>
 
 <br/>
 
 * [Unity Hub Download Link](https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.exe?_ga=2.158713850.1706525503.1610561700-1002881462.1607531977)<br/>
 *1 - After install unity hub, click on install tab and add unity version then select recommended release, no need to adding android build support and documentation modules.<br/>
 2 - After installed unity version, click on projects tab and add Object-Pooling-Algorithms-Project file as new project (you can download as a zip file)<br/>
 3 - After adding the file you must change the unity version because we used 2019.4.11f1 so cast it to unity version that you have.<br/>
 4 - Finally you can simply click on project and open.*<br/>
 
 <br/>
 
 **Scene1 includes object pooling design pattern**<br/>
 <br/>
 *After it opened you can see the Project tab below, in there go Assets->Scenes->Scene1 and double click on Scene1.<br/>
 Now you can see it opens Scene1 in Hierarcy tab left and click on ObjectSpawnerFromPool.<br/>
 Now you can see it opens ObjectSpawnerFromPool in Inspector tab right in this tab you can change SpawnTimeAmount.<br/>
 We found the required ObjectAmount as 30 in pool to run code properly (no need to change it).*<br/>
 
 <br/>
 
 **You can do the same for Scene2 which does not include object pooling design pattern, just double click on the scene you want to run and open it in Hierarchy tab left.**<br/>
 <br/>
 **The Scene2 does not have ObjectAmount in the Inspector tab because it does not have a pool to store objects, it just creates new copy of object and destroys.**<br/>
 
 <br/>
 
 *If you run Scene1 by setting ObjectSpawnTime 1000, it will show the execution time for with pooling in Console tab.<br/>
 [Test Video With Pooling](https://drive.google.com/file/d/1mjr00_DzBqyoFSPJjJsE9pxwptfhVl7K/view?usp=sharing)<br/>
 If you run Scene2 by setting ObjectSpawnTime 1000, it will show the execution time for without pooling in Console tab.<br/>
 [Test Video Without Pooling](https://drive.google.com/file/d/19aXLbJDaJoQcQ9fa8aLJtmQrixdxsUgD/view?usp=sharing)*<br/>
 <br/>
 **For this test Scene1 will executed faster than Scene2 and we can see object pooling has better performance.**<br/>
 **If you chnage ObjectSpawnTime you can make different test cases (we did 4 tests already) and see the time difference.**<br/>
 
 <br/>
 
 *In the Project tab Assets->Scripts1 you can see the codes with pooling.<br/>
 In the Project tab Assets->Scripts2 you can see the codes without pooling.*<br/>
 <br/>
 **You can find comments for explanations inside the codes.**<br/>
