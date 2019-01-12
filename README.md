# RakeshSinghPariharTest
Unity Coding Challenge(Rolling Ball)


<h2> Game Play </h2>
&nbsp Control a rolling sphere and
 collide with 10 different randomly placed cubes of two colors on a flat plane.
 
 <h2> Scoring </h2>
<p>Once the sphere collides with a cube, the score will increment by the defined amount in the
parameters set by the data. If you collide with a preceding cube of the same color, that cube’sscore will be multiplied by the current streak of “colliding with the same color”. The streak should
be displayed on the screen along with your score.</p>

 <h2> Input Controls </h2>
 &nbsp Use Left/Right arrow key to move the Sphare in Left/Right Direction.<br>
 &nbsp Use Up/Down arrow key to move the Sphare in Forward/Backward Direction.<br>
 
 <h2> Scenes </h2>
 <p>
    &nbsp There are two Scene <b>"Main Menu" </b> and <b> "Game Scene" </b>. Game Loaded from Main Menu scene. </p>
 
 <h2> Scripts </h2>
 <h3> Classes </h3>
 <p>
 <b> HUD </b> : Handle InGame HUD </br>
 <b> InputController </b> : Handle Player Input data  </br>
 <b> LoadingController </b> : Handle Loading UI  </br>
 <b> MainMenuController </b> : Handle MainMenu UI  </br>
 <b> Pickables </b> : Use to access collectable item
 <b> PlayerManager </b> : Handle Player movement and player data  </br>
 <b> ResultScreen </b> : Handle ResultScreen UI  </br>
 <b> Spawner </b> : Handle SpawnPoint in Game  </br>
 <b> UIManager </b> : Handle InGame UI  </br>
 </p>
 <h3> Static Class </h3>
 <p>
 <b> PersistentStorage </b> : Handle user data Save/Load  </br> </p>

 <h3> Abstract Class </h3>
 <p>
 <b> IBaseUI </b> : Reuse for UI root to show and hide  </br></p>
 
 <h3> Interfaces </h3>
 <p>
 <b> Iinput </b> : Reuse for player input data  </br></p>
  
 
 
