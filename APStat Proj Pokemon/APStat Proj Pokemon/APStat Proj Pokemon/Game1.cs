using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace APStat_Proj_Pokemon
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        enum GameState
        {
            Start,Instructions,Settings,Selection,OpponentChoose,ShowResults,testing,payout,MoneyOwed
        }
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PokemonType Normal = new PokemonType();
        PokemonType Fire = new PokemonType();
        PokemonType Water= new PokemonType();
        PokemonType Electric = new PokemonType();
        PokemonType Grass= new PokemonType();
        PokemonType Ice = new PokemonType();
        PokemonType Fighting= new PokemonType();
        PokemonType Poison= new PokemonType();
        PokemonType Ground = new PokemonType();
        PokemonType Flying = new PokemonType();
        PokemonType Psychic = new PokemonType();
        PokemonType Bug = new PokemonType();
        PokemonType Rock= new PokemonType();
        PokemonType Ghost= new PokemonType();
        PokemonType Dragon= new PokemonType();
        PokemonType Dark = new PokemonType();
        SpriteFont font;
        Texture2D[] instrPic = new Texture2D[5];
        Texture2D startPic;
        Dictionary<string, double> BattleResult = new Dictionary<string, double>();
        GameState state = GameState.Start;
        Rectangle BGRect = new Rectangle(0, 0, 800, 600);
        int vectX;
        string inputNum;
        KeyboardState keyboard;
        KeyboardState oldkeyboard;
        bool[] Slide = new bool[5];
        bool startOn = true;
        bool newGameState = false;
        Texture2D [] numOfTypesPic = new Texture2D[6];
        Texture2D[] numOfTypesPicSelected = new Texture2D[6];
        Rectangle OneTypeRect = new Rectangle(10, 145, 120, 170);
        Rectangle TwoTypeRect = new Rectangle(200, 145, 120, 170);
        Rectangle ThreeTypeRect = new Rectangle(390, 145, 120, 170);
        Rectangle FourTypeRect = new Rectangle(10, 350, 120, 170);
        Rectangle FiveTypeRect = new Rectangle(200, 350, 120, 170);
        Rectangle SixTypeRect = new Rectangle(390, 350, 120, 170);
        SpriteFont TitleFont;
        MouseState mouse;
        Point mousePoint;
        int numOfTypes;
        PokemonType[] chosenType = new PokemonType[6];
        bool [] choiceMade = new bool[6];
        Texture2D currentSelectPic;
        Rectangle[] typeRect = new Rectangle[16];
        Texture2D SelectionBG;
        Texture2D pixel;
        bool[] drawBackRect= new bool [6];
        Rectangle [] selectionRect = new Rectangle[6];
        MouseState oldmouse;
        int selectionNum;
        Random rand = new Random();
        PokemonType[] opponentType = new PokemonType[6];
        Texture2D battleBG;
        double RoundScore;
        double OverallScore;
        int ROUND;
        bool calculation;
        int totalWins;
        int timer=0;
        string Winnings;
        bool Bonus;
        bool FIRSTTIME = true;
        Texture2D nothingPic;
        Rectangle PrevRect = new Rectangle(10, 550, 140, 30);
        Rectangle NextRect = new Rectangle(640, 545, 140, 30);
        Rectangle startRect = new Rectangle(45, 105, 90, 20);
        Rectangle startRect2 = new Rectangle(50, 200, 160, 30);
        Rectangle showResultsRect = new Rectangle(620, 500, 130, 45);
       
        Rectangle EndgameRect = new Rectangle(45, 295, 120, 30);
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        private void DefineBattleResult()
    {
        BattleResult.Add("NormalNormal", 0);
        BattleResult.Add("NormalFire", 0);
        BattleResult.Add("NormalWater", 0);
        BattleResult.Add("NormalElectric", 0);
        BattleResult.Add("NormalGrass", 0);
        BattleResult.Add("NormalIce", 0);
        BattleResult.Add("NormalFighting", -1);
        BattleResult.Add("NormalPoison", 0);
        BattleResult.Add("NormalGround", 0);
        BattleResult.Add("NormalFlying", 0);
        BattleResult.Add("NormalPsychic", 0);
        BattleResult.Add("NormalBug", 0);
        BattleResult.Add("NormalRock", -0.5);
        BattleResult.Add("NormalGhost", 0);
        BattleResult.Add("NormalDragon", 0);
        BattleResult.Add("NormalDark", 0);

        BattleResult.Add("FireNormal", 0);
        BattleResult.Add("FireFire", 0);
        BattleResult.Add("FireWater", -1.5);
        BattleResult.Add("FireElectric", 0);
        BattleResult.Add("FireGrass", 1.5);
        BattleResult.Add("FireIce", 1.5);
        BattleResult.Add("FireFighting", 0);
        BattleResult.Add("FirePoison", 0);
        BattleResult.Add("FireGround", -1);
        BattleResult.Add("FireFlying", 0);
        BattleResult.Add("FirePsychic", 0);
        BattleResult.Add("FireBug", 1.5);
        BattleResult.Add("FireRock", -1.5);
        BattleResult.Add("FireGhost", 0);
        BattleResult.Add("FireDragon", -0.5);
        BattleResult.Add("FireDark", 0);

        BattleResult.Add("WaterNormal", 0);
        BattleResult.Add("WaterFire", 1.5);
        BattleResult.Add("WaterWater", 0);
        BattleResult.Add("WaterElectric", -1);
        BattleResult.Add("WaterGrass", -1.5);
        BattleResult.Add("WaterIce", 0.5);
        BattleResult.Add("WaterFighting", 0);
        BattleResult.Add("WaterPoison", 0);
        BattleResult.Add("WaterGround", 1);
        BattleResult.Add("WaterFlying", 0);
        BattleResult.Add("WaterPsychic", 0);
        BattleResult.Add("WaterBug", 0);
        BattleResult.Add("WaterRock", 1);
        BattleResult.Add("WaterGhost", 0);
        BattleResult.Add("WaterDragon", -0.5);
        BattleResult.Add("WaterDark", 0);

        BattleResult.Add("ElectricNormal", 0);
        BattleResult.Add("ElectricFire", 0);
        BattleResult.Add("ElectricWater", 1);
        BattleResult.Add("ElectricElectric", 0);
        BattleResult.Add("ElectricGrass", -0.5);
        BattleResult.Add("ElectricIce", 0);
        BattleResult.Add("ElectricFighting", 0);
        BattleResult.Add("ElectricPoison", 0);
        BattleResult.Add("ElectricGround", -2);
        BattleResult.Add("ElectricFlying", 1.5);
        BattleResult.Add("ElectricPsychic", 0);
        BattleResult.Add("ElectricBug", 0);
        BattleResult.Add("ElectricRock", 0);
        BattleResult.Add("ElectricGhost", 0);
        BattleResult.Add("ElectricDragon", -0.5);
        BattleResult.Add("ElectricDark", 0);

        BattleResult.Add("GrassNormal", 0);
        BattleResult.Add("GrassFire", -1.5);
        BattleResult.Add("GrassWater", 1.5);
        BattleResult.Add("GrassElectric", 0.5);
        BattleResult.Add("GrassGrass", 0);
        BattleResult.Add("GrassIce", -1);
        BattleResult.Add("GrassFighting", 0);
        BattleResult.Add("GrassPoison", -1.5);
        BattleResult.Add("GrassGround", 1.5);
        BattleResult.Add("GrassFlying", -1.5);
        BattleResult.Add("GrassPsychic", 0);
        BattleResult.Add("GrassBug", -1.5);
        BattleResult.Add("GrassRock", 0);
        BattleResult.Add("GrassGhost", 0);
        BattleResult.Add("GrassDragon", -0.5);
        BattleResult.Add("GrassDark", 0);

        BattleResult.Add("IceNormal", 0);
        BattleResult.Add("IceFire", -1.5);
        BattleResult.Add("IceWater", -0.5);
        BattleResult.Add("IceElectric", 0);
        BattleResult.Add("IceGrass", 1);
        BattleResult.Add("IceIce", 0);
        BattleResult.Add("IceFighting", -1);
        BattleResult.Add("IcePoison", 0);
        BattleResult.Add("IceGround", 1);
        BattleResult.Add("IceFlying", 1);
        BattleResult.Add("IcePsychic", 0);
        BattleResult.Add("IceBug", 0);
        BattleResult.Add("IceRock", -1);
        BattleResult.Add("IceGhost", 0);
        BattleResult.Add("IceDragon", 1);
        BattleResult.Add("IceDark", 0);

        BattleResult.Add("FightingNormal", 1);
        BattleResult.Add("FightingFire", 0);
        BattleResult.Add("FightingWater", 0);
        BattleResult.Add("FightingElectric", 0);
        BattleResult.Add("FightingGrass", 0);
        BattleResult.Add("FightingIce", 1);
        BattleResult.Add("FightingFighting", 0);
        BattleResult.Add("FightingPoison", -0.5);
        BattleResult.Add("FightingGround", 0);
        BattleResult.Add("FightingFlying", -1.5);
        BattleResult.Add("FightingPsychic", -1.5);
        BattleResult.Add("FightingBug", 0);
        BattleResult.Add("FightingRock", 1.5);
        BattleResult.Add("FightingGhost", -1);
        BattleResult.Add("FightingDragon", 0);
        BattleResult.Add("FightingDark", 1.5);

        BattleResult.Add("PoisonNormal", 0);
        BattleResult.Add("PoisonFire", 0);
        BattleResult.Add("PoisonWater", 0);
        BattleResult.Add("PoisonElectric", 0);
        BattleResult.Add("PoisonGrass", 1.5);
        BattleResult.Add("PoisonIce", 0);
        BattleResult.Add("PoisonFighting", 1);
        BattleResult.Add("PoisonPoison", 0);
        BattleResult.Add("PoisonGround", -1.5);
        BattleResult.Add("PoisonFlying", 0);
        BattleResult.Add("PoisonPsychic", -1);
        BattleResult.Add("PoisonBug", -0.5);
        BattleResult.Add("PoisonRock", -0.5);
        BattleResult.Add("PoisonGhost", -0.5);
        BattleResult.Add("PoisonDragon", 0);
        BattleResult.Add("PoisonDark", 0);

        BattleResult.Add("GroundNormal", 0);
        BattleResult.Add("GroundFire", 1);
        BattleResult.Add("GroundWater", -1);
        BattleResult.Add("GroundElectric", 2);
        BattleResult.Add("GroundGrass", -1.5);
        BattleResult.Add("GroundIce", -1);
        BattleResult.Add("GroundFighting", 0);
        BattleResult.Add("GroundPoison", 1.5);
        BattleResult.Add("GroundGround", 0);
        BattleResult.Add("GroundFlying", -1);
        BattleResult.Add("GroundPsychic", 0);
        BattleResult.Add("GroundBug", -0.5);
        BattleResult.Add("GroundRock", 1.5);
        BattleResult.Add("GroundGhost", 0);
        BattleResult.Add("GroundDragon", 0);
        BattleResult.Add("GroundDark", 0);

        BattleResult.Add("FlyingNormal", 0);
        BattleResult.Add("FlyingFire", 0);
        BattleResult.Add("FlyingWater", 0);
        BattleResult.Add("FlyingElectric", -1.5);
        BattleResult.Add("FlyingGrass", 1.5);
        BattleResult.Add("FlyingIce", -1);
        BattleResult.Add("FlyingFighting", 1.5);
        BattleResult.Add("FlyingPoison", 0);
        BattleResult.Add("FlyingGround", 1);
        BattleResult.Add("FlyingFlying", 0);
        BattleResult.Add("FlyingPsychic", 0);
        BattleResult.Add("FlyingBug", 1.5);
        BattleResult.Add("FlyingRock", -1.5);
        BattleResult.Add("FlyingGhost", 0);
        BattleResult.Add("FlyingDragon", 0);
        BattleResult.Add("FlyingDark", 0);

        BattleResult.Add("PsychicNormal", 0);
        BattleResult.Add("PsychicFire", 0);
        BattleResult.Add("PsychicWater", 0);
        BattleResult.Add("PsychicElectric", 0);
        BattleResult.Add("PsychicGrass", 0);
        BattleResult.Add("PsychicIce", 0);
        BattleResult.Add("PsychicFighting", 1.5);
        BattleResult.Add("PsychicPoison", 1);
        BattleResult.Add("PsychicGround", 0);
        BattleResult.Add("PsychicFlying", 0);
        BattleResult.Add("PsychicPsychic", 0);
        BattleResult.Add("PsychicBug", -1);
        BattleResult.Add("PsychicRock", 0);
        BattleResult.Add("PsychicGhost", -1);
        BattleResult.Add("PsychicDragon", 0);
        BattleResult.Add("PsychicDark", -2);

        BattleResult.Add("BugNormal", 0);
        BattleResult.Add("BugFire", -1.5);
        BattleResult.Add("BugWater", 0);
        BattleResult.Add("BugElectric", 0);
        BattleResult.Add("BugGrass", 1.5);
        BattleResult.Add("BugIce", 0);
        BattleResult.Add("BugFighting", 0);
        BattleResult.Add("BugPoison", -0.5);
        BattleResult.Add("BugGround", 0.5);
        BattleResult.Add("BugFlying", -1.5);
        BattleResult.Add("BugPsychic", 1);
        BattleResult.Add("BugBug", 0);
        BattleResult.Add("BugRock", -1);
        BattleResult.Add("BugGhost", -0.5);
        BattleResult.Add("BugDragon", 0);
        BattleResult.Add("BugDark", 1);

        BattleResult.Add("RockNormal", 0.5);
        BattleResult.Add("RockFire", 1.5);
        BattleResult.Add("RockWater", -1);
        BattleResult.Add("RockElectric", 0);
        BattleResult.Add("RockGrass", -1);
        BattleResult.Add("RockIce", 1);
        BattleResult.Add("RockFighting", -1.5);
        BattleResult.Add("RockPoison", 0.5);
        BattleResult.Add("RockGround", -1.5);
        BattleResult.Add("RockFlying", 1.5);
        BattleResult.Add("RockPsychic", 0);
        BattleResult.Add("RockBug", 1);
        BattleResult.Add("RockRock", 0);
        BattleResult.Add("RockGhost", 0);
        BattleResult.Add("RockDragon", 0);
        BattleResult.Add("RockDark", 0);

        BattleResult.Add("GhostNormal", 0);
        BattleResult.Add("GhostFire", 0);
        BattleResult.Add("GhostWater", 0);
        BattleResult.Add("GhostElectric", 0);
        BattleResult.Add("GhostGrass", 0);
        BattleResult.Add("GhostIce", 0);
        BattleResult.Add("GhostFighting", 2);
        BattleResult.Add("GhostPoison", 0.5);
        BattleResult.Add("GhostGround", 0);
        BattleResult.Add("GhostFlying", 0);
        BattleResult.Add("GhostPsychic", 1);
        BattleResult.Add("GhostBug", 0.5);
        BattleResult.Add("GhostRock", 0);
        BattleResult.Add("GhostGhost", 0);
        BattleResult.Add("GhostDragon", 0);
        BattleResult.Add("GhostDark", 1.5);

        BattleResult.Add("DragonNormal", 0);
        BattleResult.Add("DragonFire", 0.5);
        BattleResult.Add("DragonWater", 0.5);
        BattleResult.Add("DragonElectric", 0.5);
        BattleResult.Add("DragonGrass", 0.5);
        BattleResult.Add("DragonIce", -1);
        BattleResult.Add("DragonFighting", 0);
        BattleResult.Add("DragonPoison", 0);
        BattleResult.Add("DragonGround", 0);
        BattleResult.Add("DragonFlying", 0);
        BattleResult.Add("DragonPsychic", 0);
        BattleResult.Add("DragonBug", 0);
        BattleResult.Add("DragonRock", 0);
        BattleResult.Add("DragonGhost", 0);
        BattleResult.Add("DragonDragon", 0);
        BattleResult.Add("DragonDark", 0);

        BattleResult.Add("DarkNormal", 0);
        BattleResult.Add("DarkFire", 0);
        BattleResult.Add("DarkWater", 0);
        BattleResult.Add("DarkElectric", 0);
        BattleResult.Add("DarkGrass", 0);
        BattleResult.Add("DarkIce", 0);
        BattleResult.Add("DarkFighting", -1.5);
        BattleResult.Add("DarkPoison", 0);
        BattleResult.Add("DarkGround", 0);
        BattleResult.Add("DarkFlying", 0);
        BattleResult.Add("DarkPsychic", 2);
        BattleResult.Add("DarkBug", -1);
        BattleResult.Add("DarkRock", 0);
        BattleResult.Add("DarkGhost", 1.5);
        BattleResult.Add("DarkDragon", 0);
        BattleResult.Add("DarkDark", 0);
    }
        protected override void Initialize()
        {
            calculation = true;
            startOn = true;
            vectX = 50;
            OverallScore = 0;
            ROUND = 0;
            Winnings = "";
            RoundScore = 0;
            totalWins = 0;
            Bonus = false;
            Normal.typeString = "Normal";
            Fire.typeString = "Fire";
            Water.typeString = "Water";
            Electric.typeString = "Electric";
            Grass.typeString = "Grass";
            Ice.typeString = "Ice";
            Fighting.typeString = "Fighting";
            Poison.typeString = "Poison";
            Ground.typeString = "Ground";
            Flying.typeString = "Flying";
            Psychic.typeString = "Psychic";
            Bug.typeString = "Bug";
            Rock.typeString = "Rock";
            Ghost.typeString = "Ghost";
            Dragon.typeString = "Dragon";
            Dark.typeString = "Dark";
            Slide[0] = false;
            Slide[1] = false;
            Slide[2] = false;
            Slide[3] = false;
            Slide[4] = false;
            choiceMade[0] = false;
            choiceMade[1] = false;
            choiceMade[2] = false;
            choiceMade[3] = false;
            choiceMade[4] = false;
            choiceMade[5] = false;
            drawBackRect[0] = false;
            drawBackRect[1] = false;
            drawBackRect[2] = false;
            drawBackRect[3] = false;
            drawBackRect[4] = false;
            drawBackRect[5] = false;
            selectionNum = 0;
            state = GameState.Start;
            defineTypeRects();
            newGameState =false;
            if (FIRSTTIME == true)
            { DefineBattleResult(); }
            FIRSTTIME = false;
            opponentType[0] = null;
            opponentType[1] = null;
            opponentType[2] = null;
            opponentType[3] = null;
            opponentType[4] = null;
            opponentType[5] = null;
            chosenType[0] = null;
            chosenType[1] = null;
            chosenType[2] = null;
            chosenType[3] = null;
            chosenType[4] = null;
            chosenType[5] = null;
          
            base.Initialize();
        }
   
        private void defineTypeRects()
        {
            Normal.typeRect = new Rectangle(20, 15, 120, 170);
            Fire.typeRect = new Rectangle(135, 15, 120, 170);
            Water.typeRect= new Rectangle(250, 15, 120, 170);
            Electric.typeRect = new Rectangle(365, 15, 120, 170);
            Grass.typeRect= new Rectangle(480, 15, 120, 170);
            Ice.typeRect = new Rectangle(595, 15, 120, 170);
            Fighting.typeRect = new Rectangle(20, 190, 120, 170);
            Poison.typeRect = new Rectangle(135, 190, 120, 170);
            Ground.typeRect = new Rectangle(250, 190, 120, 170);
            Flying.typeRect = new Rectangle(365, 190, 120, 170);
            Psychic.typeRect = new Rectangle(480, 190, 120, 170);
            Bug.typeRect = new Rectangle(595, 190, 120, 170);
            Rock.typeRect= new Rectangle(145, 375, 120, 170);
            Ghost.typeRect = new Rectangle(325, 375, 120, 170);
            Dragon.typeRect= new Rectangle(510, 375, 120, 170);
            Dark.typeRect = new Rectangle(690, 375, 120, 170);
            
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Normal.typePic = Content.Load<Texture2D>("Normal");
            Fire.typePic = Content.Load<Texture2D>("Fire");
            Water.typePic = Content.Load<Texture2D>("Water");
            Electric.typePic = Content.Load<Texture2D>("Electric");
            Grass.typePic = Content.Load<Texture2D>("Grass");
            Ice.typePic = Content.Load<Texture2D>("Ice");
            Fighting.typePic = Content.Load<Texture2D>("Fighting");
            Poison.typePic = Content.Load<Texture2D>("Poison");
            Ground.typePic = Content.Load<Texture2D>("Ground");
            Flying.typePic = Content.Load<Texture2D>("Flying");
            Psychic.typePic = Content.Load<Texture2D>("Psychic");
            Bug.typePic = Content.Load<Texture2D>("Bug");
            Rock.typePic = Content.Load<Texture2D>("Rock");
            Ghost.typePic = Content.Load<Texture2D>("Ghost");
            Dragon.typePic = Content.Load<Texture2D>("Dragon");
            Dark.typePic = Content.Load<Texture2D>("Dark");
            font = Content.Load<SpriteFont>("NormalFont");
            TitleFont = Content.Load<SpriteFont>("titleFont");
            startPic = Content.Load<Texture2D>("StartPic");
            instrPic[0] = Content.Load<Texture2D>("Slide1");
            instrPic[1] = Content.Load<Texture2D>("Slide2");
            instrPic[2] = Content.Load<Texture2D>("Slide3");
            instrPic[3] = Content.Load<Texture2D>("Slide4");
            instrPic[4] = Content.Load<Texture2D>("Slide5");
            numOfTypesPic[0] = Content.Load<Texture2D>("1Type");
            numOfTypesPic[1] = Content.Load<Texture2D>("2Type");
            numOfTypesPic[2] = Content.Load<Texture2D>("3Type");
            numOfTypesPic[3] = Content.Load<Texture2D>("4Type");
            numOfTypesPic[4] = Content.Load<Texture2D>("5Type");
            numOfTypesPic[5] = Content.Load<Texture2D>("6Type");
            numOfTypesPicSelected[0] = Content.Load<Texture2D>("1TypeSelected");
            numOfTypesPicSelected[1] = Content.Load<Texture2D>("2TypeSelected");
            numOfTypesPicSelected[2] = Content.Load<Texture2D>("3TypeSelected");
            numOfTypesPicSelected[3] = Content.Load<Texture2D>("4TypeSelected");
            numOfTypesPicSelected[4] = Content.Load<Texture2D>("5TypeSelected");
            numOfTypesPicSelected[5] = Content.Load<Texture2D>("6TypeSelected");
            SelectionBG = Content.Load<Texture2D>("SelectionBack");
            pixel = Content.Load<Texture2D>("Pixel");
            battleBG = Content.Load<Texture2D>("Battle");
            nothingPic = Content.Load<Texture2D>("ClearPic");

         
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private void startDraw()
        {
           
                spriteBatch.Draw(startPic, BGRect, Color.White);
                spriteBatch.DrawString(TitleFont, "Welcome To PokeChance!", new Vector2(10, 05), Color.Black);
                spriteBatch.Draw(nothingPic, startRect, Color.Yellow);
                spriteBatch.DrawString(font, "[Start]", new Vector2(vectX, 100), Color.Black);
                spriteBatch.Draw(nothingPic, startRect2, Color.Yellow);
                spriteBatch.DrawString(font, "[Instructions]", new Vector2(vectX, 200), Color.Black);
            
           
        }
        private void startCommand()
        {
            if (startRect2.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed)
            {
                Slide[0] = true;
                Slide[4] = false;
                state = GameState.Instructions;
            }


            if (startRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed)
                    startOn = false;
             
                if (startOn == false)
                {
                    vectX += 10;
                    if (vectX == 800)
                        newGameState = true;
                }
                if (newGameState == true)
                    state = GameState.Settings;
            
            
        }
        private void instDraw()
        {
            spriteBatch.Draw(nothingPic, PrevRect, Color.White);
            spriteBatch.Draw(nothingPic, NextRect, Color.White);
            if (Slide[0] == true)
            spriteBatch.Draw(instrPic[0], BGRect, Color.White);
            if (Slide[1] == true)
                spriteBatch.Draw(instrPic[1], BGRect, Color.White);
            if (Slide[2] == true)
                spriteBatch.Draw(instrPic[2], BGRect, Color.White);
            if (Slide[3] == true)
                spriteBatch.Draw(instrPic[3], BGRect, Color.White);
            if (Slide[4] == true)
                spriteBatch.Draw(instrPic[4], BGRect, Color.White);
        }
        private void instCommand()
        {
            if (Slide[4] == true)
            {
                if (NextRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    state = GameState.Start;
                    Slide[3] = false;
                    oldmouse = mouse;
                    mouse = Mouse.GetState();
                }
                if (PrevRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    Slide[4] = false;
                    Slide[3] = true;
                    oldmouse = mouse;
                    mouse = Mouse.GetState();
                }
            }
            if (Slide[3] == true)
            {
                if (NextRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    Slide[4] = true;
                    Slide[3] = false;
                    oldmouse = mouse;
                    mouse = Mouse.GetState();
                }
                if (PrevRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    Slide[3] = false;
                    Slide[2] = true;
                    oldmouse = mouse;
                    mouse = Mouse.GetState();
                }
            }
            if (Slide[2] == true)
            {
                if (NextRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    Slide[3] = true;
                    Slide[2] = false;
                    oldmouse = mouse;
                    mouse = Mouse.GetState();
                }
                if (PrevRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    Slide[2] = false;
                    Slide[1] = true;
                    oldmouse = mouse;
                    mouse = Mouse.GetState();
                }
            }
             if (Slide[1] == true)
            {
                if (NextRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    Slide[2] = true;
                    Slide[1] = false;
                    oldmouse = mouse;
                    mouse = Mouse.GetState();
                }
                if (PrevRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    Slide[1] = false;
                    Slide[0] = true;
                    oldmouse = mouse;
                    mouse = Mouse.GetState();
                }
            } 
            if (Slide[0] == true)
            {
                if (NextRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    Slide[1] = true;
                    Slide[0] = false;
                    oldmouse = mouse;
                    mouse = Mouse.GetState();
                }
                if (PrevRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                   
                    Slide[0] = false;
                    state = GameState.Start;
                    oldmouse = mouse;
                    mouse = Mouse.GetState();
                }
            }
          
            
           
        }
         private void settingsCommand()
        {
            currentSelectPic = pixel;
            if (OneTypeRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed)
            {
                numOfTypes = 1;
                state = GameState.MoneyOwed;
                
            }
            if (TwoTypeRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed)
            {
                numOfTypes = 2;
                state = GameState.MoneyOwed;

            }
            if (ThreeTypeRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed)
            {
                numOfTypes = 3;
                state = GameState.MoneyOwed;
            }
            if (FourTypeRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed)
            {
                numOfTypes = 4;
                state = GameState.MoneyOwed;
            }
            if (FiveTypeRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed)
            {
                numOfTypes = 5;
                state = GameState.MoneyOwed;
            }
            if (SixTypeRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed)
            {
                numOfTypes = 6;
                state = GameState.MoneyOwed;
            }
        }
        private void settingsDraw()
        {
            spriteBatch.Draw(startPic, BGRect, Color.White);
            spriteBatch.DrawString(TitleFont, "How Many Types Do You \n Want To Buy?", new Vector2(10, 05), Color.Black);
            spriteBatch.Draw(numOfTypesPic[0], OneTypeRect, Color.White);
            if (OneTypeRect.Contains(mousePoint))
                spriteBatch.Draw(numOfTypesPicSelected[0], OneTypeRect, Color.White);
            spriteBatch.Draw(numOfTypesPic[1], TwoTypeRect, Color.White);
            if (TwoTypeRect.Contains(mousePoint))
                spriteBatch.Draw(numOfTypesPicSelected[1], TwoTypeRect, Color.White);
            spriteBatch.Draw(numOfTypesPic[2],ThreeTypeRect, Color.White);
            if (ThreeTypeRect.Contains(mousePoint))
                spriteBatch.Draw(numOfTypesPicSelected[2], ThreeTypeRect, Color.White);
            spriteBatch.Draw(numOfTypesPic[3], FourTypeRect, Color.White);
            if (FourTypeRect.Contains(mousePoint))
                spriteBatch.Draw(numOfTypesPicSelected[3], FourTypeRect, Color.White);
            spriteBatch.Draw(numOfTypesPic[4], FiveTypeRect, Color.White);
            if (FiveTypeRect.Contains(mousePoint))
                spriteBatch.Draw(numOfTypesPicSelected[4], FiveTypeRect, Color.White);
            spriteBatch.Draw(numOfTypesPic[5], SixTypeRect, Color.White);
            if (SixTypeRect.Contains(mousePoint))
                spriteBatch.Draw(numOfTypesPicSelected[5], SixTypeRect, Color.White);
        }
       private void MouseOver()
        {
            if (Normal.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Normal.typePic;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    SelectionProcess(Normal);
                }
            }
            if (Fire.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Fire.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Fire);
                }
            }
            if (Water.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Water.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Water);
                }
            }
            if (Electric.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Electric.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Electric);
                }
            }
            if (Grass.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Grass.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Grass);
                }
            }
            if (Ice.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Ice.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Ice);
                }
            }
            if (Fighting.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Fighting.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Fighting);
                }
            }
            if (Poison.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Poison.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Poison);
                }
            }
            if (Ground.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Ground.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Ground);
                }
            }
            if (Flying.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Flying.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Flying);
                }
            }
            if (Psychic.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Psychic.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Psychic);
                }
            }
            if (Bug.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Bug.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Bug);
                }
            }
            if (Rock.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Rock.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Rock);
                }
            }
            if (Ghost.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Ghost.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Ghost);
                }
            }
            if (Dragon.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Dragon.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Dragon);
                }
            }
            if (Dark.typeRect.Contains(mousePoint))
            {
                currentSelectPic = Dark.typePic;
                if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    SelectionProcess(Dark);
                }
            }
        }

       private void SelectionProcess(PokemonType type)
       {
           if (chosenType[0] != type && chosenType[1] != type && chosenType[2] != type && chosenType[3] != type && chosenType[4] != type && chosenType[5] != type)
           {
               selectionRect[selectionNum] = type.typeRect;
               choiceMade[selectionNum] = true;
               if (selectionNum != 0)
                   choiceMade[selectionNum - 1] = false;
               chosenType[selectionNum] = type;
               drawBackRect[selectionNum] = true;
               if (numOfTypes == (selectionNum + 1))
               {
                   state = GameState.OpponentChoose;
               }

           }
       } 
        private void selectionCommand()
       {
           
           
              
           if (choiceMade[0] == true)
               selectionNum = 1;
           if (choiceMade[1] == true)
               selectionNum = 2;
           if (choiceMade[2] == true)
               selectionNum= 3;
           if (choiceMade[3] == true)
               selectionNum = 4;
           if (choiceMade[4] == true)
               selectionNum = 5;

            MouseOver();

        }

        
        private void selectionDraw()
        {
            spriteBatch.Draw(SelectionBG, BGRect, Color.White);
            if (drawBackRect[0] == true)
                spriteBatch.Draw(pixel, selectionRect[0], Color.Yellow);
            if (drawBackRect[1] == true)
                 spriteBatch.Draw(pixel, selectionRect[1], Color.Yellow);
            if (drawBackRect[2] == true)
                 spriteBatch.Draw(pixel, selectionRect[2], Color.Yellow);
            if (drawBackRect[3] == true)
                 spriteBatch.Draw(pixel, selectionRect[3], Color.Yellow);
            if (drawBackRect[4] == true)
                 spriteBatch.Draw(pixel, selectionRect[4], Color.Yellow);
            if (drawBackRect[5] == true)
                 spriteBatch.Draw(pixel, selectionRect[5], Color.Yellow);
            spriteBatch.Draw(Normal.typePic, Normal.typeRect, Color.White);
            spriteBatch.Draw(Fire.typePic, Fire.typeRect, Color.White);
            spriteBatch.Draw(Water.typePic, Water.typeRect, Color.White);
            spriteBatch.Draw(Electric.typePic, Electric.typeRect, Color.White);
            spriteBatch.Draw(Grass.typePic, Grass.typeRect, Color.White);
            spriteBatch.Draw(Ice.typePic, Ice.typeRect, Color.White);
            spriteBatch.Draw(Fighting.typePic, Fighting.typeRect, Color.White);
            spriteBatch.Draw(Poison.typePic, Poison.typeRect, Color.White);
            spriteBatch.Draw(Ground.typePic, Ground.typeRect, Color.White);
            spriteBatch.Draw(Flying.typePic, Flying.typeRect, Color.White);
            spriteBatch.Draw(Psychic.typePic, Psychic.typeRect, Color.White);
            spriteBatch.Draw(Bug.typePic, Bug.typeRect, Color.White);
            spriteBatch.Draw(Rock.typePic, Rock.typeRect, Color.White);
            spriteBatch.Draw(Ghost.typePic, Ghost.typeRect, Color.White);
            spriteBatch.Draw(Dragon.typePic, Dragon.typeRect, Color.White);
            spriteBatch.Draw(Dark.typePic, Dark.typeRect, Color.White);
            spriteBatch.Draw(pixel, new Rectangle(10, 420, 120, 170), Color.White);
            spriteBatch.Draw(currentSelectPic, new Rectangle(10, 420, 120, 170), Color.White);
           
        }

        private void OpponentChooseCommand()
        {
            int j;
            for (int i = 0; i < numOfTypes; i++)
            {
                j = rand.Next(1, 17);
                if (j == 1)
                {
                    if (opponentType[0] != Normal && opponentType[1] != Normal && opponentType[2] != Normal && opponentType[3] != Normal && opponentType[4] != Normal && opponentType[5] != Normal)
                    { opponentType[i] = Normal; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 2)
                {
                    if (opponentType[0] != Fire && opponentType[1] != Fire && opponentType[2] != Fire && opponentType[3] != Fire && opponentType[4] != Fire && opponentType[5] != Fire)
                    { opponentType[i] = Fire; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 3)
                {
                    if (opponentType[0] != Water && opponentType[1] != Water && opponentType[2] != Water && opponentType[3] != Water && opponentType[4] != Water && opponentType[5] != Water)
                    { opponentType[i] = Water; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 4)
                {
                    if (opponentType[0] != Electric && opponentType[1] != Electric && opponentType[2] != Electric && opponentType[3] != Electric && opponentType[4] != Electric && opponentType[5] != Electric)
                    { opponentType[i] = Electric; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 5)
                {
                    if (opponentType[0] != Grass && opponentType[1] != Grass && opponentType[2] != Grass && opponentType[3] != Grass && opponentType[4] != Grass && opponentType[5] != Grass)
                    { opponentType[i] = Grass; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 6)
                {
                    if (opponentType[0] != Ice && opponentType[1] != Ice && opponentType[2] != Ice && opponentType[3] != Ice && opponentType[4] != Ice && opponentType[5] != Ice)
                    { opponentType[i] = Ice; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 7)
                {
                    if (opponentType[0] != Fighting && opponentType[1] != Fighting && opponentType[2] != Fighting && opponentType[3] != Fighting && opponentType[4] != Fighting && opponentType[5] != Fighting)
                    { opponentType[i] = Fighting; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 8)
                {
                    if (opponentType[0] != Poison && opponentType[1] != Poison && opponentType[2] != Poison && opponentType[3] != Poison && opponentType[4] != Poison && opponentType[5] != Poison)
                    { opponentType[i] = Poison; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 9)
                {
                    if (opponentType[0] != Ground && opponentType[1] != Ground && opponentType[2] != Ground && opponentType[3] != Ground && opponentType[4] != Ground && opponentType[5] != Ground)
                    { opponentType[i] = Ground; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 10)
                {
                    if (opponentType[0] != Flying && opponentType[1] != Flying && opponentType[2] != Flying && opponentType[3] != Flying && opponentType[4] != Flying && opponentType[5] != Flying)
                    { opponentType[i] = Flying; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 11)
                {
                    if (opponentType[0] != Psychic && opponentType[1] != Psychic && opponentType[2] != Psychic && opponentType[3] != Psychic && opponentType[4] != Psychic && opponentType[5] != Psychic)
                    { opponentType[i] = Psychic; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 12)
                {
                    if (opponentType[0] != Bug && opponentType[1] != Bug && opponentType[2] != Bug && opponentType[3] != Bug && opponentType[4] != Bug && opponentType[5] != Bug)
                    { opponentType[i] = Bug; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 13)
                {
                    if (opponentType[0] != Rock && opponentType[1] != Rock && opponentType[2] != Rock && opponentType[3] != Rock && opponentType[4] != Rock && opponentType[5] != Rock)
                    { opponentType[i] = Rock; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 14)
                {
                    if (opponentType[0] != Ghost && opponentType[1] != Ghost && opponentType[2] != Ghost && opponentType[3] != Ghost && opponentType[4] != Ghost && opponentType[5] != Ghost)
                    { opponentType[i] = Ghost; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 15)
                {
                    if (opponentType[0] != Dragon && opponentType[1] != Dragon && opponentType[2] != Dragon && opponentType[3] != Dragon && opponentType[4] != Dragon && opponentType[5] != Dragon)
                    { opponentType[i] = Dragon; }
                    else
                    {
                        i--;
                    }
                }
                if (j == 16)
                {
                    if (opponentType[0] != Dark && opponentType[1] != Dark && opponentType[2] != Dark && opponentType[3] != Dark && opponentType[4] != Dark && opponentType[5] != Dark)
                    { opponentType[i] = Dark; }
                    else
                    {
                        i--;
                    }
                }
            }
            state = GameState.ShowResults;
        }
        private void ShowResultsCommand()
        {
            RoundScore = BattleResult[chosenType[ROUND].typeString + opponentType[ROUND].typeString];
            
            if (calculation == true)
            {
                OverallScore = RoundScore + OverallScore;
                calculation = false;
                if (RoundScore > 0)
                    totalWins++;
            }
            if (showResultsRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
            {

                if (ROUND == (numOfTypes-1))
                {
                    state = GameState.payout;
                }
                else
                {
                    ROUND++;
                }
                calculation = true;
            }
        }
        private void ShowResultsDraw()
        {
            spriteBatch.Draw(battleBG, BGRect, Color.White);
            spriteBatch.Draw(opponentType[ROUND].typePic,new Rectangle(80,170,120,170),Color.White);
            spriteBatch.Draw(chosenType[ROUND].typePic, new Rectangle(510, 170, 120, 170), Color.White);
            spriteBatch.DrawString(font, RoundScore.ToString(), new Vector2(577, 550), Color.Black);
            spriteBatch.DrawString(font, OverallScore.ToString(), new Vector2(564, 16), Color.Black);
            spriteBatch.Draw(nothingPic, showResultsRect, Color.White);
            if (RoundScore <= 0)
                spriteBatch.DrawString(TitleFont, "ROUND LOST", new Vector2(220, 330), Color.Black);
            if (RoundScore > 0)
                spriteBatch.DrawString(TitleFont, "ROUND WON", new Vector2(220, 332), Color.Black);
            spriteBatch.DrawString(TitleFont, "[Next]", new Vector2(620, 480), Color.White);
        }
        private void payoutCommand()
        {
            keyboard = Keyboard.GetState();
         if ((keyboard.IsKeyDown(Keys.Enter) && oldkeyboard.IsKeyUp(Keys.Enter))||(EndgameRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed))
            { 
                   oldkeyboard = keyboard;
                   Initialize();
            }
            if ((totalWins == numOfTypes)&& numOfTypes>1)
                Bonus = true;
     if (Bonus == false)
           {
            if (OverallScore <= 0)
                Winnings = "I'm sorry, you lost...Feel free to try again!";
            if (OverallScore == 0.5)
               Winnings = "Congrats! You win $2!";
            if (OverallScore == 1.0)
                Winnings = "Congrats! You win $3!";
            if (OverallScore == 1.5)
                Winnings = "Congrats! You win $4!";
            if (OverallScore >= 2)
                Winnings = "OMG YOU SCORED BIG!! $10!!!!";
          }

     if (Bonus == true)
     {
         
         if (numOfTypes == 2)
         {
             if (OverallScore == 0.5)
                 Winnings = "Congrats! You win (2 + 3(bonus) = ) $5!";
             if (OverallScore == 1.0)
                 Winnings = "Congrats! You win (3 + 3(bonus) =) $6!";
             if (OverallScore == 1.5)
                 Winnings = "Congrats! You win (4 +3 (bonus) =) $7!";
             if (OverallScore >= 2)
                 Winnings = "OMG YOU SCORED BIG!! (10 + 3 (bonus) = ) $13!!!!";
         }
         if (numOfTypes == 3)
         {
             if (OverallScore == 0.5)
                 Winnings = "Congrats! You win (2 + 10 (bonus) =) 12!";
             if (OverallScore == 1.0)
                 Winnings = "Congrats! You win (3 + 10(bonus) =) $13!";
             if (OverallScore == 1.5)
                 Winnings = "Congrats! You win (4 + 10 (bonus) =) $14!";
             if (OverallScore >= 2)
                 Winnings = "OMG YOU SCORED BIG!! (10 + 10(bonus) = ) $20!!!!";
         }
         if (numOfTypes == 4)
         {
             if (OverallScore == 0.5)
                 Winnings = "Congrats! You win (2 + 20 (bonus) =) $22!";
             if (OverallScore == 1.0)
                 Winnings = "Congrats! You win (3 + 20 (bonus) =) $23!";
             if (OverallScore == 1.5)
                 Winnings = "Congrats! You win (4 + 20 (bonus) = ) $24!";
             if (OverallScore >= 2)
                 Winnings = "OMG YOU SCORED BIG!! (10 + 20 (bonus) = ) $30!!!!";
         }
         if (numOfTypes == 5)
         {
             if (OverallScore == 0.5)
                 Winnings = "Congrats! You win (2 + 50 (bonus) = ) $52!";
             if (OverallScore == 1.0)
                 Winnings = "Congrats! You win (3 + 50 (bonus) = ) $53!";
             if (OverallScore == 1.5)
                 Winnings = "Congrats! You win (4 + 50 (bonus) = ) $54!";
             if (OverallScore >= 2)
                 Winnings = "OMG YOU SCORED BIG!! (10 +50 (bonus) = ) $55!!!!";
         }
         if (numOfTypes == 6)
         {
             if (OverallScore == 0.5)
                 Winnings = "Congrats! You win (2 + 100 (bonus) =) $102!";
             if (OverallScore == 1.0)
                 Winnings = "Congrats! You win (3 + 100(bonus) =) $103!";
             if (OverallScore == 1.5)
                 Winnings = "Congrats! You win (4 + 100(bonus) =) $104!";
             if (OverallScore >= 2)
                 Winnings = "OMG YOU SCORED BIG!! (10 +100(bonus) = ) $110!!!!";
         }  
         
         oldkeyboard = keyboard;
     }

            
            
        }
        private void payoutDraw()
        {
            
           
            if (Bonus == false)
            {
                spriteBatch.Draw(startPic, BGRect, Color.White);
                spriteBatch.DrawString(TitleFont, "THANK YOU FOR PLAYING!", new Vector2(10, 05), Color.Black);
                spriteBatch.DrawString(font, Winnings, new Vector2(50, 100), Color.Black);
                spriteBatch.DrawString(font, "No Bonus Added", new Vector2(50, 200), Color.Black);
                spriteBatch.DrawString(font, "Overall Score:" + OverallScore.ToString(), new Vector2(50,250),Color.Black);
                spriteBatch.DrawString(font, "[END GAME]", new Vector2(50, 300), Color.Black);
                spriteBatch.Draw(nothingPic, EndgameRect, Color.Yellow);
            }
            if (Bonus == true)
            {
                spriteBatch.Draw(startPic, BGRect, Color.White);
                spriteBatch.DrawString(TitleFont, "THANK YOU FOR PLAYING!", new Vector2(10, 05), Color.Black);
                spriteBatch.DrawString(font, Winnings, new Vector2(50, 100), Color.Black);
                spriteBatch.DrawString(font, "WOW! GOOD JOB ON THE BONUS!", new Vector2(50, 200), Color.Black);
                spriteBatch.DrawString(font, "Overall Score:" + OverallScore.ToString(), new Vector2(50, 250), Color.Black);
                spriteBatch.DrawString(font, "[END GAME]", new Vector2(50, 300), Color.Black);
                spriteBatch.Draw(nothingPic, EndgameRect, Color.Yellow);
            }

        }
        private void MoneyOwedCommand()
        {
            if ((keyboard.IsKeyDown(Keys.Enter) && oldkeyboard.IsKeyUp(Keys.Enter))||(EndgameRect.Contains(mousePoint) && mouse.LeftButton == ButtonState.Pressed))
                state = GameState.Selection;
        }
        private void MoneyOwedDraw()
        {
            spriteBatch.Draw(startPic, BGRect, Color.White);
            spriteBatch.Draw(pixel, EndgameRect, Color.White);
            spriteBatch.DrawString(font, "[PAID]", new Vector2(50, 300), Color.Black);
            spriteBatch.DrawString(TitleFont, "Please Pay " + numOfTypes.ToString() + "$ \n to continue", new Vector2(20, 100), Color.Black);
        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();
            mousePoint = new Point(mouse.X, mouse.Y);
            switch (state)
            {
                case GameState.Start:
                    startCommand();
                    break;
                case GameState.Instructions:
                    instCommand();
                    break;
                case GameState.Settings:
                    settingsCommand();
                    break;
                case GameState.Selection:
                    selectionCommand();
                    break;
                case GameState.OpponentChoose:
                    OpponentChooseCommand();
                    break;
                case GameState.ShowResults:
                    ShowResultsCommand();
                    break;
                case GameState.payout:
                    payoutCommand();
                    break;
                case GameState.MoneyOwed:
                    MoneyOwedCommand();
                    break;
            }
            oldkeyboard = keyboard;
            oldmouse = mouse;
            base.Update(gameTime);
        }
        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            IsMouseVisible = true;
            spriteBatch.Begin();
            switch (state)
            {
                case GameState.Start:
                    startDraw();
                    break;
                case GameState.Instructions:
                    instDraw();
                    break;
                case GameState.Settings:
                    settingsDraw();
                    break;
                case GameState.Selection:
                    selectionDraw();
                    break;
                case GameState.OpponentChoose:
                    spriteBatch.Draw(SelectionBG, BGRect, Color.White);
                    break;
                case GameState.ShowResults:
                    ShowResultsDraw();
                    break;           
                case GameState.payout:
                    payoutDraw();
                    break;
                case GameState.MoneyOwed:
                    MoneyOwedDraw();
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
