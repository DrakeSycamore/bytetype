using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBanks : MonoBehaviour
{
    public int bankTotal;
    public List<List<string>> AllBanks = new List<List<string>>();
    public List<string> currentBank = new List<string>();

    void Awake()
    {   
        WordDropper drop = FindObjectOfType<WordDropper>();
        for (int i = 0; i < bankTotal; i++)
        {
            AllBanks.Add(new List<string>());
        }
        AddBanks();
    }

    public void AddBanks()
    {   
        // Debug aka The Origin
        AllBanks[99] = new List<string>()
        {
        "Bocchi the Rock", "Hitori Gotoh", "Yamada Ryo", "Ichiji Nijika", "Kita Ikuyo", "Ichiji Seika", "Kikuri Hiroi", "PA-san",
        "Oshi no Ko", "Hoshino Ai","Hoshino Aquamarine", "Hoshino Ruby", "Arima Kana", "Shiranui Frill", "Kurokawa Akane", "Kimetsu no Yaiba",
        "Kamado Tanjiro", "Kamado Nezuko", "Agatsuma Zenitsu", "Hashibara Inosuke", "Chainsaw Man", "Denji", "Power",
        "Makima", "Hayakawa Aki", "Higashiyama Kobeni", "Himeno", "Beam", "Reze", "Naruto", "Goku", "Sailor Moon", "Luffy", "Ichigo", "Sasuke",
        "Vegeta", "Sakura", "Kakashi", "Kirito", "Asuna", "Eren", "Mikasa", "Levi", "Jotaro Kujo", "Dio Brando", "Josuke Higashikata",  "Giorno Giovanna",
        "Kira Yoshikage", "Saitama", "Genos", "Tatsumaki", "Mob", "Reigen", "Rimuru Tempest", "Shizu", "Benimaru", "Shion", "Shuna", "Milim Nova",
        "Veldora", "Gabiru", "Saber", "Shirou Emiya", "Archer", "Saber Alter", "Rin Tohsaka", "All Might", "Deku", "Katsuki Bakugo", "Shoto Todoroki", "Ochaco Uraraka",
        "Tsuyu Asui", "Tenya Iida",  "Kirishima Eijiro",  "Momo Yaoyorozu", "Denki Kaminari", "Jiro Kyoka", "Froppy", "Eraserhead", "Midnight", "Gran Torino",
        "Endeavor", "Hawks", "Mirko",  "Tokino Sora","Roboco", "Sakura Miko","Hoshimachi Suisei","AZKi","Yozora Mel","Natsuiro Matsuri","Aki Rosenthal","Akai Haato",
        "Shirakami Fubuki","Ookami Mio","Nekomata Okayu","Inugami Korone","Usada Pekora","Uruha Rushia","Shiranui Flare","Shirogane Noel","Houshou Marine",
        "Amane Kanata","Kiryu Coco","Tsunomaki Watame","Tokoyami Towa","Himemori Luna","Yukihana Lamy","Momosuzu Nene","Shishiro Botan","Omaru Polka","Kureiji Ollie",
        "Mori Calliope","Takanashi Kiara","Ninomae Ina'nis","Gawr Gura","Amelia Watson","Watson Amelia","Nanashi Mumei","Ayunda Risu","Moona Hoshinova","Airani Iofifteen",
        };

        // Area 1 - Level 1 (System Unit)
        AllBanks[0] = new List<string>()
        {
        "CPU", "GPU", "RAM", "SSD", "HDD", "Motherboard", "PowerSupply",
        "GraphicsCard", "Processor", "Memory", "Storage", "Peripheral",
        "Monitor", "Resolution", "FrameRate", "Voltage", "Cooling", "USB",
        "Ethernet", "Bluetooth", "WiFi", "Mouse", "Keyboard", "Joystick",
        "SoundCard", "Driver", "BIOS", "Chipset", "Socket", "Bus", "Cache",
        "Firmware", "VRAM", "LAN", "WAN", "BusSpeed", "Pixel", "Shader",
        "VR", "AR", "Microphone", "Speakers", "Fan", "HeatSink", "Case",
        "OperatingSystem", "Bit", "Byte", "ClockSpeed"
        };


        // Area 1 - Level 2 (Programming Terms)
        AllBanks[1] = new List<string>()
        {
        "Unity", "CSharp", "Scripting", "Shader", "Algorithm", "Compiler",
        "Debugger", "Framework", "Engine", "Graphics", "Renderer", "Texture",
        "Material", "Prefab", "Scene", "GameObject", "Component", "Script",
        "Asset", "Plugin", "Library", "Runtime", "Compilation", "Serialization",
        "API", "VersionControl", "Git", "Repository", "Merge", "Branch",
        "Bug", "Patch", "Update", "PatchNotes", "Deployment", "Build", "Compile",
        "Runtime", "Console", "Log", "Error", "Exception", "Profiler", "Debugging",
        "Optimization", "Framework", "SDK", "IDE", "Viewport"
        };

        // Area 1 - Level 3 (CyberSecurity)
        AllBanks[2] = new List<string>()
        {
        "Kernel", "Daemon", "Registry", "Rootkit", "Firewall", "Pipelining",
        "Firmware", "Rasterization", "Decryption", "Bootstrapping", "Concatenation",
        "Interpolation", "Backdoor", "Checksum", "Semaphore", "Virtualization",
        "Heuristic", "Obfuscation", "AsymmetricEncryption", "Bitwise",
        "Blockchain", "PacketSniffing", "Cybersecurity", "Salting", "DenialOfService",
        "DNSPoisoning", "ZeroDay", "ManInTheMiddle", "LoadBalancing", "Redundancy",
        "SpectreAttack", "RowHammer", "BiometricAuthentication", "VolatileMemory",
        "FirmwareHacking", "EphemeralKey", "SideChannelAttack", "Nonce", "RainbowTable",
        "SessionHijacking", "BiosRootkit", "PolymorphicCode", "Worm", "TrojanHorse",
        "Ransomware", "ZeroKnowledgeProof", "DNSCrypt", "Honeypot"
        };

        //Area 1 - Level 4 (Networking)
        AllBanks[3] = new List<string>()
        { 
        "FiberOptic", "EthernetCable", "CoaxialCable", "TwistedPair", "Backbone",
        "Interconnect", "PatchPanel", "Modem", "Router", "Gateway", "Firewall",
        "LoadBalancer", "Transceiver", "AccessPoint", "Hub", "Switch", "Gateway",
        "Topology", "Latency", "Bandwidth", "PacketLoss", "Jitter", "Redundancy",
        "MeshNetwork", "WideAreaNetwork", "LocalAreaNetwork", "VirtualPrivateNetwork",
        "IPAddress", "SubnetMask", "Gateway", "DomainNameSystem", "ProxyServer",
        "InternetServiceProvider", "TransmissionControlProtocol", "UserDatagramProtocol",
        "Protocol", "PortForwarding", "Socket", "SecureSocketsLayers", "TransportLayerSecurity",
        "DomainHostConfigurationProtocol", "NetworkAddressTranslation", "MediaAccessControlAddress",
        "Gateway", "InternetExchangePoint", "Traceroute", "Ping", "Domain", "UniformResourceLocator", "Server"
        };


        //Area 1 - Level 5 (Computer Errors and Issues)
        AllBanks[4] = new List<string>()
        {
        "Overheating", "Throttling", "PowerSurge", "BlueScreen", "Freeze",
        "KernelPanic", "Crash", "BootLoop", "Corruption", "Malware", "Virus",
        "Spyware", "Ransomware", "Trojan", "Worm", "Phishing", "Keylogger",
        "Rootkit", "Adware", "Botnet", "BufferOverflow", "DLLError", "RuntimeError",
        "LogicError", "SegFault", "Deadlock", "RaceCondition", "DependencyConflict",
        "MemoryLeak", "DiskFull", "DataLoss", "BadSector", "ScreenTearing", "Artifacting",
        "Ghosting", "InputLag", "FrameDrop", "TextureFlickering", "RenderingGlitch",
        "NetworkCongestion", "PacketCollision", "DNSIssue", "ConnectionTimeout",
        "FirewallBlock", "SSLHandshakeError", "BlueScreenOfDeath", "SystemFailure",
        "BIOSCorruption", "FirmwareBug"
        };

        //Area 2 -  Level 1 (The Internet)
        AllBanks[5] = new List<string>()
        {
        "Internet", "WebBrowser", "Website", "Webpage", "URL", "Domain",
        "Hyperlink", "HTTP", "HTTPS", "FTP", "Server", "Client",
        "Download", "Upload", "Bandwidth", "Streaming", "Firewall", "Router",
        "Modem", "Ethernet", "Wi-Fi", "ISP", "DNS", "IPAddress",
        "Cookies", "Cache", "HTML", "CSS", "JavaScript", "AJAX",
        "API", "CloudComputing", "Cybersecurity", "Phishing", "Malware",
        "Firewall", "VPN", "Encryption", "Decryption", "Authentication", "Authorization",
        "Session", "Cookies", "Cache", "WebDevelopment", "ResponsiveDesign", "UserExperience",
        "WebHosting", "SearchEngine", "SocialMedia", "OnlineGaming"
        };

        //Area 2 - Level 2 (Internet Error and Issues)
        AllBanks[6] = new List<string>()
        {
        "Latency", "PacketLoss", "ConnectionTimeout", "DNSFailure", "NetworkCongestion",
        "BandwidthLimit", "FirewallBlock", "RouterFailure", "ModemIssues", "ISPProblem",
        "Downtime", "ServerCrash", "DNSHijacking", "PhishingAttack", "MalwareInfection",
        "RansomwareAttack", "DDoSAttack", "DataBreach", "ManInTheMiddleAttack", "SSLHandshakeError",
        "AuthenticationFailure", "AuthorizationError", "SessionHijacking", "CookieExploitation",
        "CacheCorruption", "BrowserCompatibility", "CrossSiteScripting", "CrossSiteRequestForgery",
        "BrokenLink", "404Error", "503Error", "502Error", "504Error", "BrowserFreeze",
        "BrowserCrash", "PopUpAds", "TrackingCookies", "PlugInIssues", "CAPTCHAFailure",
        "PaymentGatewayError", "OnlineTransactionFailure", "StreamingBuffering", "VideoBuffering",
        "VoiceChatIssues", "VoIPProblems", "OnlineGamingLag", "LatencySpikes", "ServerOverload",
        "BackboneFailure", "InternetOutage"
        };

        //Area 2 - Level 3 (Unity Game)
        AllBanks[7] = new List<string>()
        {
            "Game", "Unity", "CSharp", "Scripting", "Graphics", "Renderer",
        "Physics", "Animation", "GameObject", "Asset", "Prefab", "Scene",
        "LevelDesign", "Character", "NPC", "Player", "Enemy", "AI",
        "HUD", "UI", "Inventory", "Respawn", "Checkpoint", "Camera",
        "Controls", "Input", "Sound", "Music", "SFX", "Dialogue",
        "Quest", "PowerUp", "Obstacle", "Puzzle", "Simulation", "VR",
        "AR", "Multiplayer", "Leaderboard", "Achievement", "Monetization",
        "Microtransaction", "LootBox", "GamingCommunity", "BetaTesting", "BugTesting",
        "Optimization", "Debugging", "Playtesting"
    };

        //Area 2 - Level 4 (Game Development)
        AllBanks[8] = new List<string>()
        {
        "Gameplay", "Immersion", "LevelDesign", "Environment", "CharacterAnimation",
        "ArtificialIntelligence", "RenderPipeline", "PhysicsEngine", "CollisionDetection",
        "ProceduralGeneration", "Cutscene", "GameMechanics", "InventorySystem", "QuestDesign",
        "DialogueSystem", "Respawn", "Checkpoint", "HUD", "PowerUp", "HealthBar",
        "Multiplayer", "Cooperative", "Competitive", "Leaderboard", "Matchmaking", "Lobby",
        "Avatar", "Emote", "EasterEgg", "Speedrun", "BetaTesting", "Debugging",
        "Localization", "Monetization", "Microtransactions", "DLC", "GameEngine", "ScriptableObject",
        "Prefab", "ParticleSystem", "ShaderProgramming", "Raycasting", "TextureMapping", "Polygon",
        "RagdollPhysics", "Rigidbody", "Projectile", "AnimationCurve", "BlendTree", "StateMachine",
        "InverseKinematics", "Networking", "LatencyCompensation"
        };

        //Area 2 - Level 5 (Game Development Errors and Issues)
        AllBanks[9] = new List<string>()
        {
        "Bugs", "Crashes", "Glitches", "Freezing", "FrameDrops", "MemoryLeak",
        "Incompatibility", "CollisionIssues", "PhysicsBugs", "AnimationGlitches", "AIProblems",
        "NetworkingErrors", "Latency", "SyncIssues", "InputLag", "UIBugs", "ScalingProblems",
        "AssetImportErrors", "ShaderBugs", "LightingIssues", "RenderingArtifacts", "TextureProblems",
        "SoundGlitches", "MusicLooping", "SaveGameErrors", "LoadingScreenHangs", "PerformanceDegradation",
        "CompatibilityErrors", "PlatformSpecificBugs", "CrossPlatformIssues", "ScriptingErrors",
        "CodeOptimization", "MemoryConsumption", "ResourceManagement", "BuildErrors", "DeploymentProblems",
        "VersionControlConflicts", "IntegrationIssues", "LocalizationBugs", "MonetizationProblems",
        "MicrotransactionErrors", "DLCCompatibility", "GameBalanceIssues", "QuestBugs", "RespawnFailures",
        "CheckpointErrors", "UserInterfaceBugs", "PowerUpMalfunctions", "HealthBarGlitches"
        };
    }  
}
