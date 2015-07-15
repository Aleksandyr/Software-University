   function Update()
{
 if(Input.GetKeyDown("r"))
 {
  // Plays the reload animation - stops all other animations
  animation.Play("reload", PlayMode.StopAll);
 }
}