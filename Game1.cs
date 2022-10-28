using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
namespace ghostControl;

public class Game1 : Game
{

    private int w;
    private int h;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Rydge.Player player;
    private List<Rydge.Ground> grounds;
    private List<Rydge.Ghost> ghosts;
    private List<Rydge.Goblin> goblins;
    private List<Rydge.Ground> savedBlocks;
    private List<Rydge.Ghost> collectedGhosts;
    private Texture2D end;
    private Texture2D start;
    private Texture2D endBad;
    private Texture2D background;
    private int savedGhosts;
    private bool endLevel;
    private string startGameInput;
    private bool startGame;
    private int cooldown;
    private int flyTime;

    private int[,] Level;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        this.ghosts = new List<Rydge.Ghost>();
        this.goblins = new List<Rydge.Goblin>();
        this.grounds = new List<Rydge.Ground>();
        this.savedBlocks = new List<Rydge.Ground>();
        this.collectedGhosts = new List<Rydge.Ghost>();
        this.endLevel = false;
        this.savedGhosts = 0;
        this.cooldown = 0;
        this.flyTime = 100;
        this.startGame = false;
        this.w = _graphics.PreferredBackBufferWidth;
        this.h = _graphics.PreferredBackBufferHeight;
        this.Level = new int[,]{
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,1},
            {1,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,3,3,3,3,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,1},
            {1,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,0,0,1,0,0,0,1,0,0,1,0,0,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,4,0,0,0,0,0,0,4,0,0,0,4,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };
        for (int x = 0; x < 15; x++)
        {
            for (int y = 0; y < 25; y++)
            {
                if (Level[x, y] == 1)
                {
                    Console.WriteLine("Placed ground");
                    Rydge.Ground g = new Rydge.Ground();
                    g.setxpos(y * 32);
                    g.setypos(x * 32);
                    grounds.Add(g);

                }
                if (Level[x, y] == 3)
                {
                    Console.WriteLine("Placed Save Block");
                    Rydge.Ground g = new Rydge.Ground();
                    g.setxpos(y * 32);
                    g.setypos(x * 32);
                    savedBlocks.Add(g);
                }
                if (Level[x, y] == 0)
                {
                    Console.WriteLine("Placed blank Space");
                }
                if (Level[x, y] == 5)
                {
                    Console.WriteLine("Placed Player");
                    this.player = new Rydge.Player();
                    player.setxpos(y * 32);
                    player.setypos(x * 32);

                }
                if (Level[x, y] == 2)
                {
                    Console.WriteLine("Placed Ghost");
                    Rydge.Ghost g = new Rydge.Ghost();
                    g.setxpos(y * 32);
                    g.setypos(x * 32);
                    ghosts.Add(g);
                }
                if (Level[x, y] == 4)
                {
                    Console.WriteLine("Placed Goblin");
                    Rydge.Goblin g = new Rydge.Goblin();
                    g.setxpos(y * 32);
                    g.setypos(x * 32);
                    goblins.Add(g);
                }

            }
        }
        // for (int i = 0; i < 5; i++)
        // {
        //     Rydge.Ghost g = new Rydge.Ghost();
        //     ghosts.Add(g);
        //     ghosts[i].setxpos(i * 32 + 60 * (i + 1));
        // }
        // for (int i = 0; i < goblins.Length; i++)
        // {
        //     goblins[i] = new Rydge.Goblin();
        //     goblins[i].setypos(225);
        //     goblins[i].setxpos(i * 32 + 60 * (i + 2));
        // }
        // for (int i = 0; i < grounds.Length; i++)
        // {
        //     grounds[i] = new Rydge.Ground();
        //     grounds[i].setxpos(i * 32);

        // }
        // for (int i = 0; i < savedBlocks.Length; i++)
        // {
        //     savedBlocks[i] = new Rydge.Ground();
        //     savedBlocks[i].setxpos(i * 32);
        //     savedBlocks[i].setypos(150);
        // }


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        this.player.setPLayerTexture(Content.Load<Texture2D>("astro"));
        this.start = Content.Load<Texture2D>("start");
        this.end = Content.Load<Texture2D>("savedAll");
        this.endBad = Content.Load<Texture2D>("savedBad");
        this.background = Content.Load<Texture2D>("Background");
        foreach (Rydge.Ground ground in grounds)
        {
            ground.setTexture(Content.Load<Texture2D>("ground"));
        }
        foreach (Rydge.Ghost ghost in ghosts)
        {
            ghost.setTexture(Content.Load<Texture2D>("Ghost"));
        }
        foreach (Rydge.Ground saved in savedBlocks)
        {
            saved.setTexture(Content.Load<Texture2D>("saveBlock"));
        }
        foreach (Rydge.Goblin goblin in goblins)
        {
            goblin.setTexture(Content.Load<Texture2D>("Goblin"));
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (startGame == false)
        {
            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Enter))
            {
                startGame = true;
            }
        }
        else if (!endLevel)
        {
            if (cooldown > 0)
            {
                cooldown--;
            }
            Console.WriteLine($"{this.player.getxpos()}, {this.player.getypos()}");
            bool touchingGround = false;


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //movement
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                if (flyTime != 0)
                {
                    this.player.changeypos(-(this.player.getyvel() * (float)gameTime.ElapsedGameTime.TotalSeconds));
                    flyTime--;
                }
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                this.player.changexpos(-(this.player.getxvel() * (float)gameTime.ElapsedGameTime.TotalSeconds));
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                this.player.changexpos(+(this.player.getxvel() * (float)gameTime.ElapsedGameTime.TotalSeconds));
            }

            //Collision save block
            foreach (Rydge.Ground saved in this.savedBlocks)
            {
                if (playerColidesGround(this.player, saved))
                {
                    touchingGround = true;
                }
            }
            //collision player and ground
            foreach (Rydge.Ground ground in this.grounds)
            {
                if (playerColidesGround(this.player, ground))
                {
                    flyTime = 30;
                    touchingGround = true;
                }
            }
            //collision with ghosts
            foreach (Rydge.Ghost ghost in this.ghosts)
            {
                if (playerColidesGhost(this.player, ghost))
                {

                    Console.WriteLine($"Player Collides with ghost: {ghost}");
                    collectedGhosts.Add(ghost);
                }
            }
            //remove ghost
            foreach (Rydge.Ghost ghost in this.collectedGhosts)
            {
                if (ghosts.Contains(ghost))
                {
                    ghosts.Remove(ghost);
                }
            }
            //collision with goblin
            if (cooldown == 0)
            {
                foreach (Rydge.Goblin goblin in this.goblins)
                {
                    if (playerColidesGoblin(this.player, goblin))
                    {
                        //Add a cooldown
                        cooldown = 200;
                        Console.WriteLine($"Player Collides with ghost: {goblin}");
                        if (collectedGhosts.Count > 0)
                        {
                            ghosts.Add(collectedGhosts[0]);
                            collectedGhosts.RemoveAt(0);
                        }

                    }
                }
            }

            //check colide with save block

            foreach (Rydge.Ground saved in this.savedBlocks)
            {

                if (playerColidesSaveBlock(this.player, saved))
                {
                    Console.WriteLine($"Player Collides with saved block: {saved}");
                    savedGhosts = collectedGhosts.Count;
                    Console.WriteLine($"You saved {savedGhosts} space ghosts");
                    endLevel = true;
                }
            }
            if (touchingGround)
            {
                Console.WriteLine("Colides");
                if (kstate.IsKeyDown(Keys.Down))
                {
                    this.player.changeypos((this.player.getyvel() * (float)gameTime.ElapsedGameTime.TotalSeconds));
                }
                else if (kstate.IsKeyDown(Keys.Up))
                {
                    this.player.changeypos((this.player.getyvel() * (float)gameTime.ElapsedGameTime.TotalSeconds));
                }
                else if (kstate.IsKeyDown(Keys.Left))
                {
                    this.player.changexpos(-(this.player.getxvel() * (float)gameTime.ElapsedGameTime.TotalSeconds));
                }
                else if (kstate.IsKeyDown(Keys.Right))
                {
                    this.player.changexpos((this.player.getxvel() * (float)gameTime.ElapsedGameTime.TotalSeconds));
                }
            }
            else
            {
                Console.WriteLine("No Colides");
                if (!kstate.IsKeyDown(Keys.Up) || flyTime == 0)
                {
                    this.player.changeypos(+(this.player.getyvel() * (float)gameTime.ElapsedGameTime.TotalSeconds));
                    this.player.changeyvel(1);
                }
            }
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        if (startGame == false)
        {
            _spriteBatch.Draw(start, new Vector2(0, 0), Color.White);
        }
        else if (!endLevel)
        {
            _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(player.getPlayerTexture(), new Vector2(this.player.getxpos(), this.player.getypos()), Color.White);
            for (int i = 0; i < grounds.Count; i++)
            {
                _spriteBatch.Draw(grounds[i].getTexture(), new Vector2(grounds[i].getxpos(), grounds[i].getypos()), Color.White);
            }
            for (int i = 0; i < ghosts.Count; i++)
            {
                _spriteBatch.Draw(ghosts[i].getTexture(), new Vector2(ghosts[i].getxpos(), ghosts[i].getypos()), Color.White);
            }
            for (int i = 0; i < savedBlocks.Count; i++)
            {
                _spriteBatch.Draw(savedBlocks[i].getTexture(), new Vector2(savedBlocks[i].getxpos(), savedBlocks[i].getypos()), Color.White);
            }
            for (int i = 0; i < goblins.Count; i++)
            {
                _spriteBatch.Draw(goblins[i].getTexture(), new Vector2(goblins[i].getxpos(), goblins[i].getypos()), Color.White);
            }
            for (int i = 0; i < collectedGhosts.Count; i++)
            {
                collectedGhosts[i].setxpos(player.getxpos() - 33 * (i + 1));
                collectedGhosts[i].setypos(player.getypos());
                _spriteBatch.Draw(collectedGhosts[i].getTexture(), new Vector2(collectedGhosts[i].getxpos(), collectedGhosts[i].getypos()), Color.White);
            }
        }
        else if (collectedGhosts.Count == 5)
        {
            _spriteBatch.Draw(end, new Vector2(0, 0), Color.White);
        }
        else
        {
            _spriteBatch.Draw(endBad, new Vector2(0, 0), Color.White);
        }
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    #region Collisions 
    bool playerColidesGhost(Rydge.Player p, Rydge.Ghost g)
    {
        if (p.getxpos() < g.getxpos() + g.getxsize() &&
        p.getxpos() + p.getxsize() > g.getxpos()
        && p.getypos() < g.getypos() + g.getysize() &&
        p.getypos() + p.getysize() > g.getypos())
            return true;
        else
            return false;
    }
    bool playerColidesGoblin(Rydge.Player p, Rydge.Goblin g)
    {
        if (p.getxpos() < g.getxpos() + g.getxsize() &&
        p.getxpos() + p.getxsize() > g.getxpos()
        && p.getypos() < g.getypos() + g.getysize() &&
        p.getypos() + p.getysize() > g.getypos())
            return true;
        else

            return false;
    }
    bool playerColidesSaveBlock(Rydge.Player p, Rydge.Ground g)
    {
        if (p.getxpos() < g.getxpos() + g.getxsize() &&
        p.getxpos() + p.getxsize() > g.getxpos()
        && p.getypos() < g.getypos() + g.getysize() &&
        p.getypos() + p.getysize() > g.getypos())
            return true;
        else
            return false;
    }
    bool playerColidesGround(Rydge.Player p, Rydge.Ground g)

    {
        if (p.getxpos() < g.getxpos() + g.getxsize() &&
        p.getxpos() + p.getxsize() > g.getxpos()
        && p.getypos() < g.getypos() + g.getysize() &&
        p.getypos() + p.getysize() > g.getypos())
            return true;
        else
            return false;
    }
    #endregion
}

