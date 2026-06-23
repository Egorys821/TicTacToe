using Godot;
using System;
using TicTakToe;
public partial class GameCell : Button
{
   

    public FieldType FieldType { get; private set; }
    public Coordinate Location { get; private set; }

    private void UpdateUI()
    {
        char futureChar = ' ';
        switch (FieldType)
        {
            case FieldType.X:
                futureChar = 'X';
                break;
            case FieldType.O:
                futureChar = 'O';
                break;
        }
        Text = "" + futureChar;
    }

    public void Init(Coordinate location, FieldType type)
    {
        FieldType = type;
        Location = location;

        UpdateUI();

    }
    public override void _Ready()
    {
        Pressed += Click;
    }
    public void Click()
    {
        // usefull stuff
        if (Variables.Game.TryMakeMove(Location))
        {
            GD.Print(Variables.Game.GetGameState());

            WinCondition wc = Variables.Game.CheckForWinCondition(Location);
            if (wc != WinCondition.UNKNOWN)
            {
                GD.Print(wc);
                return;
            }

            FieldType = Variables.Game.CurrentPlayer.Type;
            UpdateUI();
            Variables.Game.ChangePlayers();

        }

        // Debug Info
        GD.Print(Location.X, Location.Y, FieldType);
    }

    public override void _Process(double delta)
    {
    }
}
