using Godot;
using System;
using TicTakToe;

public partial class GameScene : Node
{
    PackedScene GameCellScene;
    Game Game = null;
    GridContainer Container = null;

    public override void _Ready()
    {
        

        Container = GetNode<GridContainer>("GridContainer");
        GameCellScene = GD.Load<PackedScene>(GamePaths.GameCellPath);

        GD.Print("Load");

        Variables.Player1 = new Player("Adam", FieldType.X, "Hurray!");
        Variables.Player2 = new Player("Betheny", FieldType.O, "I am better");

        GD.Print("Player");

        Game = new GameBuilder()
            .WithPlayer(Variables.Player1)
            .WithPlayer(Variables.Player2)
            .WithInitialFieldSize(5)
            .WithWinLength(3)
            .WithFixedFieldSize(true)
            .Build();

        GD.Print("GameBuilder");

        Variables.Game = Game;

        //TODO GameCell cellInstance = GameCellScene.Instantiate<GameCell>();
        //TODO cellInstance.Init(new Coordinate(0,0), FieldType.X);
        Container.Columns = Game.FieldWidth;

        for (int i = 0; i < Game.FieldWidth; i++)
        {
            for (int j = 0; j < Game.FieldHeight; j++)
            {
                GameCell cellInstance = GameCellScene.Instantiate<GameCell>();
                cellInstance.Init(new Coordinate(i, j), FieldType.Empty);
                Container.AddChild(cellInstance);
            }
        }

        
        
        

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
