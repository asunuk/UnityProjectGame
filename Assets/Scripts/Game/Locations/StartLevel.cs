namespace Game.Locations
{
	public class StartLevel : Level
	{

		public override LevelType levelType => LevelType.StartLevel;
		public override Chunk[,] levelMap => null;
		public override float gravity => 9.81f;
	}
}
