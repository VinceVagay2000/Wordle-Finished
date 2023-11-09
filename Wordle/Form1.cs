using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//This version has no error checking if the word input is actually a real word
//Still accepts characters that aren't letters
//Doesn't handle double letters like the real wordle
//Coded by Vince Vagay 26/3/22
namespace Wordle
{
    public partial class Form1 : Form
    {
        //Global variable that initializes the word to guess
        string word = "";
        public Form1()
        {
            InitializeComponent();
            //Enter key presses button
            AcceptButton = this.enterBtn;
            //The word to guess
            //Picks a random word from the list
            List<string> wordList = new List<string> { "cigar", "rebut", "sissy", "humph", "awake", "blush", "focal", "evade", "naval", "serve", "heath", "dwarf", "model", "karma", "stink", "grade", "quiet", "bench", "abate", "feign", "major", "death", "fresh", "crust", "stool", "colon", "abase", "marry", "react", "batty", "pride", "floss", "helix", "croak", "staff", "paper", "unfed", "whelp", "trawl", "outdo", "adobe", "crazy", "sower", "repay", "digit", "crate", "cluck", "spike", "mimic", "pound", "maxim", "linen", "unmet", "flesh", "booby", "forth", "first", "stand", "belly", "ivory", "seedy", "print", "yearn", "drain", "bribe", "stout", "panel", "crass", "flume", "offal", "agree", "error", "swirl", "argue", "bleed", "delta", "flick", "totem", "wooer", "front", "shrub", "parry", "biome", "lapel", "start", "greet", "goner", "golem", "lusty", "loopy", "round", "audit", "lying", "gamma", "labor", "islet", "civic", "forge", "corny", "moult", "basic", "salad", "agate", "spicy", "spray", "essay", "fjord", "spend", "kebab", "guild", "aback", "motor", "alone", "hatch", "hyper", "thumb", "dowry", "ought", "belch", "dutch", "pilot", "tweed", "comet", "jaunt", "enema", "steed", "abyss", "growl", "fling", "dozen", "boozy", "erode", "world", "gouge", "click", "briar", "great", "altar", "pulpy", "blurt", "coast", "duchy", "groin", "fixer", "group", "rogue", "badly", "smart", "pithy", "gaudy", "chill", "heron", "vodka", "finer", "surer", "radio", "rouge", "perch", "retch", "wrote", "clock", "tilde", "store", "prove", "bring", "solve", "cheat", "grime", "exult", "usher", "epoch", "triad", "break", "rhino", "viral", "conic", "masse", "sonic", "vital", "trace", "using", "peach", "champ", "baton", "brake", "pluck", "craze", "gripe", "weary", "picky", "acute", "ferry", "aside", "tapir", "troll", "unify", "rebus", "boost", "truss", "siege", "tiger", "banal", "slump", "crank", "gorge", "query", "drink", "favor", "abbey", "tangy", "panic", "solar", "shire", "proxy", "point", "robot", "prick", "wince", "crimp", "knoll", "sugar", "whack", "mount", "perky", "could", "wrung", "light", "those", "moist", "shard", "pleat", "aloft", "skill", "elder", "frame", "humor", "pause", "ulcer", "ultra", "robin", "cynic", "aroma", "caulk", "shake", "dodge", "swill", "tacit", "other", "thorn", "trove", "bloke", "vivid", "spill", "chant", "choke", "rupee", "nasty", "mourn", "ahead", "brine", "cloth", "hoard", "sweet", "month", "lapse", "watch", "today", "focus", "smelt", "tease", "cater", "movie", "saute", "allow", "renew", "their", "slosh", "purge", "chest", "depot", "epoxy", "nymph", "found", "shall", "stove", "lowly", "snout", "trope", "fewer", "shawl", "natal", "comma", "foray", "scare", "stair", "black", "squad", "royal", "chunk", "mince", "shame", "cheek", "ample", "flair", "foyer", "cargo", "oxide", "plant", "olive", "inert", "askew", "heist", "shown", "zesty", "trash", "larva", "forgo", "story", "hairy", "train", "homer", "badge", "midst", "canny", "fetus", "butch", "farce", "slung", "tipsy", "metal", "yield", "delve", "being", "scour", "glass", "gamer", "scrap", "money", "hinge", "album", "vouch", "asset", "tiara", "crept", "bayou", "atoll", "manor", "creak", "showy", "phase", "froth", "depth", "gloom", "flood", "trait", "girth", "piety", "goose", "float", "donor", "atone", "primo", "apron", "blown", "cacao", "loser", "input", "gloat", "awful", "brink", "smite", "beady", "rusty", "retro", "droll", "gawky", "hutch", "pinto", "egret", "lilac", "sever", "field", "fluff", "flack", "agape", "voice", "stead", "stalk", "berth", "madam", "night", "bland", "liver", "wedge", "augur", "roomy", "wacky", "flock", "angry", "trite", "aphid", "tryst", "midge", "power", "elope", "cinch", "motto", "stomp", "upset", "bluff", "cramp", "quart", "coyly", "youth", "rhyme", "buggy", "alien", "smear", "unfit", "patty", "cling", "glean", "label", "hunky", "khaki", "poker", "gruel", "twice", "twang", "shrug", "treat", "waste", "merit", "woven", "needy", "clown", "widow", "irony", "ruder", "gauze", "chief", "onset", "prize", "fungi", "charm", "gully", "inter", "whoop", "taunt", "leery", "class", "theme", "lofty", "tibia", "booze", "alpha", "thyme", "doubt", "parer", "chute", "stick", "trice", "alike", "recap", "saint", "glory", "grate", "admit", "brisk", "soggy", "usurp", "scald", "scorn", "leave", "twine", "sting", "bough", "marsh", "sloth", "dandy", "vigor", "howdy", "enjoy", "valid", "ionic", "equal", "floor", "catch", "spade", "stein", "exist", "quirk", "denim", "grove", "spiel", "mummy", "fault", "foggy", "flout", "carry", "sneak", "libel", "waltz", "aptly", "piney", "inept", "aloud", "photo", "dream", "stale", "unite", "snarl", "baker", "there", "glyph", "pooch", "hippy", "spell", "folly", "louse", "gulch", "vault", "godly", "threw", "fleet", "grave", "inane", "shock", "crave", "spite", "valve", "skimp", "claim", "rainy", "musty", "pique", "daddy", "quasi", "arise", "aging", "valet", "opium", "avert", "stuck", "recut", "mulch", "genre", "plume", "rifle", "count", "incur", "total", "wrest", "mocha", "deter", "study", "lover", "safer", "rivet", "funny", "smoke", "mound", "undue", "sedan", "pagan", "swine", "guile", "gusty", "equip", "tough", "canoe", "chaos", "covet", "human", "udder", "lunch", "blast", "stray", "manga", "melee", "lefty", "quick", "paste", "given", "octet", "risen", "groan", "leaky", "grind", "carve", "loose", "sadly", "spilt", "apple", "slack", "honey", "final", "sheen", "eerie", "minty", "slick", "derby", "wharf", "spelt", "coach", "erupt", "singe", "price", "spawn", "fairy", "jiffy", "filmy", "stack", "chose", "sleep", "ardor", "nanny", "niece", "woozy", "handy", "grace", "ditto", "stank", "cream", "usual", "diode", "valor", "angle", "ninja", "muddy", "chase", "reply", "prone", "spoil", "heart", "shade", "diner", "arson", "onion", "sleet", "dowel", "couch", "palsy", "bowel", "smile", "evoke", "creek", "lance", "eagle", "idiot", "siren", "built", "embed", "award", "dross", "annul", "goody", "frown", "patio", "laden", "humid", "elite", "lymph", "edify", "might", "reset", "visit", "gusto", "purse", "vapor", "crock", "write", "sunny", "loath", "chaff", "slide", "queer", "venom", "stamp", "sorry", "still", "acorn", "aping", "pushy", "tamer", "hater", "mania", "awoke", "brawn", "swift", "exile", "birch", "lucky", "freer", "risky", "ghost", "plier", "lunar", "winch", "snare", "nurse", "house", "borax", "nicer", "lurch", "exalt", "about", "savvy", "toxin", "tunic", "pried", "inlay", "chump", "lanky", "cress", "eater", "elude", "cycle", "kitty", "boule", "moron", "tenet", "place", "lobby", "plush", "vigil", "index", "blink", "clung", "qualm", "croup", "clink", "juicy", "stage", "decay", "nerve", "flier", "shaft", "crook", "clean", "china", "ridge", "vowel", "gnome", "snuck", "icing", "spiny", "rigor", "snail", "flown", "rabid", "prose", "thank", "poppy", "budge", "fiber", "moldy", "dowdy", "kneel", "track", "caddy", "quell", "dumpy", "paler", "swore", "rebar", "scuba", "splat", "flyer", "horny", "mason", "doing", "ozone", "amply", "molar", "ovary", "beset", "queue", "cliff", "magic", "truce", "sport", "fritz", "edict", "twirl", "verse", "llama", "eaten", "range", "whisk", "hovel", "rehab", "macaw", "sigma", "spout", "verve", "sushi", "dying", "fetid", "brain", "buddy", "thump", "scion", "candy", "chord", "basin", "march", "crowd", "arbor", "gayly", "musky", "stain", "dally", "bless", "bravo", "stung", "title", "ruler", "kiosk", "blond", "ennui", "layer", "fluid", "tatty", "score", "cutie", "zebra", "barge", "matey", "bluer", "aider", "shook", "river", "privy", "betel", "frisk", "bongo", "begun", "azure", "weave", "genie", "sound", "glove", "braid", "scope", "wryly", "rover", "assay", "ocean", "bloom", "irate", "later", "woken", "silky", "wreck", "dwelt", "slate", "smack", "solid", "amaze", "hazel", "wrist", "jolly", "globe", "flint", "rouse", "civil", "vista", "relax", "cover", "alive", "beech", "jetty", "bliss", "vocal", "often", "dolly", "eight", "joker", "since", "event", "ensue", "shunt", "diver", "poser", "worst", "sweep", "alley", "creed", "anime", "leafy", "bosom", "dunce", "stare", "pudgy", "waive", "choir", "stood", "spoke", "outgo", "delay", "bilge", "ideal", "clasp", "seize", "hotly", "laugh", "sieve", "block", "meant", "grape", "noose", "hardy", "shied", "drawl", "daisy", "putty", "strut", "burnt", "tulip", "crick", "idyll", "vixen", "furor", "geeky", "cough", "naive", "shoal", "stork", "bathe", "aunty", "check", "prime", "brass", "outer", "furry", "razor", "elect", "evict", "imply", "demur", "quota", "haven", "cavil", "swear", "crump", "dough", "gavel", "wagon", "salon", "nudge", "harem", "pitch", "sworn", "pupil", "excel", "stony", "cabin", "unzip", "queen", "trout", "polyp", "earth", "storm", "until", "taper", "enter", "child", "adopt", "minor", "fatty", "husky", "brave", "filet", "slime", "glint", "tread", "steal", "regal", "guest", "every", "murky", "share", "spore", "hoist", "buxom", "inner", "otter", "dimly", "level", "sumac", "donut", "stilt", "arena", "sheet", "scrub", "fancy", "slimy", "pearl", "silly", "porch", "dingo", "sepia", "amble", "shady", "bread", "friar", "reign", "dairy", "quill", "cross", "brood", "tuber", "shear", "posit", "blank", "villa", "shank", "piggy", "freak", "which", "among", "fecal", "shell", "would", "algae", "large", "rabbi", "agony", "amuse", "bushy", "copse", "swoon", "knife", "pouch", "ascot", "plane", "crown", "urban", "snide", "relay", "abide", "viola", "rajah", "straw", "dilly", "crash", "amass", "third", "trick", "tutor", "woody", "blurb", "grief", "disco", "where", "sassy", "beach", "sauna", "comic", "clued", "creep", "caste", "graze", "snuff", "frock", "gonad", "drunk", "prong", "lurid", "steel", "halve", "buyer", "vinyl", "utile", "smell", "adage", "worry", "tasty", "local", "trade", "finch", "ashen", "modal", "gaunt", "clove", "enact", "adorn", "roast", "speck", "sheik", "missy", "grunt", "snoop", "party", "touch", "mafia", "emcee", "array", "south", "vapid", "jelly", "skulk", "angst", "tubal", "lower", "crest", "sweat", "cyber", "adore", "tardy", "swami", "notch", "groom", "roach", "hitch", "young", "align", "ready", "frond", "strap", "puree", "realm", "venue", "swarm", "offer", "seven", "dryer", "diary", "dryly", "drank", "acrid", "heady", "theta", "junto", "pixie", "quoth", "bonus", "shalt", "penne", "amend", "datum", "build", "piano", "shelf", "lodge", "suing", "rearm", "coral", "ramen", "worth", "psalm", "infer", "overt", "mayor", "ovoid", "glide", "usage", "poise", "randy", "chuck", "prank", "fishy", "tooth", "ether", "drove", "idler", "swath", "stint", "while", "begat", "apply", "slang", "tarot", "radar", "credo", "aware", "canon", "shift", "timer", "bylaw", "serum", "three", "steak", "iliac", "shirk", "blunt", "puppy", "penal", "joist", "bunny", "shape", "beget", "wheel", "adept", "stunt", "stole", "topaz", "chore", "fluke", "afoot", "bloat", "bully", "dense", "caper", "sneer", "boxer", "jumbo", "lunge", "space", "avail", "short", "slurp", "loyal", "flirt", "pizza", "conch", "tempo", "droop", "plate", "bible", "plunk", "afoul", "savoy", "steep", "agile", "stake", "dwell", "knave", "beard", "arose", "motif", "smash", "broil", "glare", "shove", "baggy", "mammy", "swamp", "along", "rugby", "wager", "quack", "squat", "snaky", "debit", "mange", "skate", "ninth", "joust", "tramp", "spurn", "medal", "micro", "rebel", "flank", "learn", "nadir", "maple", "comfy", "remit", "gruff", "ester", "least", "mogul", "fetch", "cause", "oaken", "aglow", "meaty", "gaffe", "shyly", "racer", "prowl", "thief", "stern", "poesy", "rocky", "tweet", "waist", "spire", "grope", "havoc", "patsy", "truly", "forty", "deity", "uncle", "swish", "giver", "preen", "bevel", "lemur", "draft", "slope", "annoy", "lingo", "bleak", "ditty", "curly", "cedar", "dirge", "grown", "horde", "drool", "shuck", "crypt", "cumin", "stock", "gravy", "locus", "wider", "breed", "quite", "chafe", "cache", "blimp", "deign", "fiend", "logic", "cheap", "elide", "rigid", "false", "renal", "pence", "rowdy", "shoot", "blaze", "envoy", "posse", "brief", "never", "abort", "mouse", "mucky", "sulky", "fiery", "media", "trunk", "yeast", "clear", "skunk", "scalp", "bitty", "cider", "koala", "duvet", "segue", "creme", "super", "grill", "after", "owner", "ember", "reach", "nobly", "empty", "speed", "gipsy", "recur", "smock", "dread", "merge", "burst", "kappa", "amity", "shaky", "hover", "carol", "snort", "synod", "faint", "haunt", "flour", "chair", "detox", "shrew", "tense", "plied", "quark", "burly", "novel", "waxen", "stoic", "jerky", "blitz", "beefy", "lyric", "hussy", "towel", "quilt", "below", "bingo", "wispy", "brash", "scone", "toast", "easel", "saucy", "value", "spice", "honor", "route", "sharp", "bawdy", "radii", "skull", "phony", "issue", "lager", "swell", "urine", "gassy", "trial", "flora", "upper", "latch", "wight", "brick", "retry", "holly", "decal", "grass", "shack", "dogma", "mover", "defer", "sober", "optic", "crier", "vying", "nomad", "flute", "hippo", "shark", "drier", "obese", "bugle", "tawny", "chalk", "feast", "ruddy", "pedal", "scarf", "cruel", "bleat", "tidal", "slush", "semen", "windy", "dusty", "sally", "igloo", "nerdy", "jewel", "shone", "whale", "hymen", "abuse", "fugue", "elbow", "crumb", "pansy", "welsh", "syrup", "terse", "suave", "gamut", "swung", "drake", "freed", "afire", "shirt", "grout", "oddly", "tithe", "plaid", "dummy", "broom", "blind", "torch", "enemy", "again", "tying", "pesky", "alter", "gazer", "noble", "ethos", "bride", "extol", "decor", "hobby", "beast", "idiom", "utter", "these", "sixth", "alarm", "erase", "elegy", "spunk", "piper", "scaly", "scold", "hefty", "chick", "sooty", "canal", "whiny", "slash", "quake", "joint", "swept", "prude", "heavy", "wield", "femme", "lasso", "maize", "shale", "screw", "spree", "smoky", "whiff", "scent", "glade", "spent", "prism", "stoke", "riper", "orbit", "cocoa", "guilt", "humus", "shush", "table", "smirk", "wrong", "noisy", "alert", "shiny", "elate", "resin", "whole", "hunch", "pixel", "polar", "hotel", "sword", "cleat", "mango", "rumba", "puffy", "filly", "billy", "leash", "clout", "dance", "ovate", "facet", "chili", "paint", "liner", "curio", "salty", "audio", "snake", "fable", "cloak", "navel", "spurt", "pesto", "balmy", "flash", "unwed", "early", "churn", "weedy", "stump", "lease", "witty", "wimpy", "spoof", "saner", "blend", "salsa", "thick", "warty", "manic", "blare", "squib", "spoon", "probe", "crepe", "knack", "force", "debut", "order", "haste", "teeth", "agent", "widen", "icily", "slice", "ingot", "clash", "juror", "blood", "abode", "throw", "unity", "pivot", "slept", "troop", "spare", "sewer", "parse", "morph", "cacti", "tacky", "spool", "demon", "moody", "annex", "begin", "fuzzy", "patch", "water", "lumpy", "admin", "omega", "limit", "tabby", "macho", "aisle", "skiff", "basis", "plank", "verge", "botch", "crawl", "lousy", "slain", "cubic", "raise", "wrack", "guide", "foist", "cameo", "under", "actor", "revue", "fraud", "harpy", "scoop", "climb", "refer", "olden", "clerk", "debar", "tally", "ethic", "cairn", "tulle", "ghoul", "hilly", "crude", "apart", "scale", "older", "plain", "sperm", "briny", "abbot", "rerun", "quest", "crisp", "bound", "befit", "drawn", "suite", "itchy", "cheer", "bagel", "guess", "broad", "axiom", "chard", "caput", "leant", "harsh", "curse", "proud", "swing", "opine", "taste", "lupus", "gumbo", "miner", "green", "chasm", "lipid", "topic", "armor", "brush", "crane", "mural", "abled", "habit", "bossy", "maker", "dusky", "dizzy", "lithe", "brook", "jazzy", "fifty", "sense", "giant", "surly", "legal", "fatal", "flunk", "began", "prune", "small", "slant", "scoff", "torus", "ninny", "covey", "viper", "taken", "moral", "vogue", "owing", "token", "entry", "booth", "voter", "chide", "elfin", "ebony", "neigh", "minim", "melon", "kneed", "decoy", "voila", "ankle", "arrow", "mushy", "tribe", "cease", "eager", "birth", "graph", "odder", "terra", "weird", "tried", "clack", "color", "rough", "weigh", "uncut", "ladle", "strip", "craft", "minus", "dicey", "titan", "lucid", "vicar", "dress", "ditch", "gypsy", "pasta", "taffy", "flame", "swoop", "aloof", "sight", "broke", "teary", "chart", "sixty", "wordy", "sheer", "leper", "nosey", "bulge", "savor", "clamp", "funky", "foamy", "toxic", "brand", "plumb", "dingy", "butte", "drill", "tripe", "bicep", "tenor", "krill", "worse", "drama", "hyena", "think", "ratio", "cobra", "basil", "scrum", "bused", "phone", "court", "camel", "proof", "heard", "angel", "petal", "pouty", "throb", "maybe", "fetal", "sprig", "spine", "shout", "cadet", "macro", "dodgy", "satyr", "rarer", "binge", "trend", "nutty", "leapt", "amiss", "split", "myrrh", "width", "sonar", "tower", "baron", "fever", "waver", "spark", "belie", "sloop", "expel", "smote", "baler", "above", "north", "wafer", "scant", "frill", "awash", "snack", "scowl", "frail", "drift", "limbo", "fence", "motel", "ounce", "wreak", "revel", "talon", "prior", "knelt", "cello", "flake", "debug", "anode", "crime", "salve", "scout", "imbue", "pinky", "stave", "vague", "chock", "fight", "video", "stone", "teach", "cleft", "frost", "prawn", "booty", "twist", "apnea", "stiff", "plaza", "ledge", "tweak", "board", "grant", "medic", "bacon", "cable", "brawl", "slunk", "raspy", "forum", "drone", "women", "mucus", "boast", "toddy", "coven", "tumor", "truer", "wrath", "stall", "steam", "axial", "purer", "daily", "trail", "niche", "mealy", "juice", "nylon", "plump", "merry", "flail", "papal", "wheat", "berry", "cower", "erect", "brute", "leggy", "snipe", "sinew", "skier", "penny", "jumpy", "rally", "umbra", "scary", "modem", "gross", "avian", "greed", "satin", "tonic", "parka", "sniff", "livid", "stark", "trump", "giddy", "reuse", "taboo", "avoid", "quote", "devil", "liken", "gloss", "gayer", "beret", "noise", "gland", "dealt", "sling", "rumor", "opera", "thigh", "tonga", "flare", "wound", "white", "bulky", "etude", "horse", "circa", "paddy", "inbox", "fizzy", "grain", "exert", "surge", "gleam", "belle", "salvo", "crush", "fruit", "sappy", "taker", "tract", "ovine", "spiky", "frank", "reedy", "filth", "spasm", "heave", "mambo", "right", "clank", "trust", "lumen", "borne", "spook", "sauce", "amber", "lathe", "carat", "corer", "dirty", "slyly", "affix", "alloy", "taint", "sheep", "kinky", "wooly", "mauve", "flung", "yacht", "fried", "quail", "brunt", "grimy", "curvy", "cagey", "rinse", "deuce", "state", "grasp", "milky", "bison", "graft", "sandy", "baste", "flask", "hedge", "girly", "swash", "boney", "coupe", "endow", "abhor", "welch", "blade", "tight", "geese", "miser", "mirth", "cloud", "cabal", "leech", "close", "tenth", "pecan", "droit", "grail", "clone", "guise", "ralph", "tango", "biddy", "smith", "mower", "payee", "serif", "drape", "fifth", "spank", "glaze", "allot", "truck", "kayak", "virus", "testy", "tepee", "fully", "zonal", "metro", "curry", "grand", "banjo", "axion", "bezel", "occur", "chain", "nasal", "gooey", "filer", "brace", "allay", "pubic", "raven", "plead", "gnash", "flaky", "munch", "dully", "eking", "thing", "slink", "hurry", "theft", "shorn", "pygmy", "ranch", "wring", "lemon", "shore", "mamma", "froze", "newer", "style", "moose", "antic", "drown", "vegan", "chess", "guppy", "union", "lever", "lorry", "image", "cabby", "druid", "exact", "truth", "dopey", "spear", "cried", "chime", "crony", "stunk", "timid", "batch", "gauge", "rotor", "crack", "curve", "latte", "witch", "bunch", "repel", "anvil", "soapy", "meter", "broth", "madly", "dried", "scene", "known", "magma", "roost", "woman", "thong", "punch", "pasty", "downy", "knead", "whirl", "rapid", "clang", "anger", "drive", "goofy", "email", "music", "stuff", "bleep", "rider", "mecca", "folio", "setup", "verso", "quash", "fauna", "gummy", "happy", "newly", "fussy", "relic", "guava", "ratty", "fudge", "femur", "chirp", "forte", "alibi", "whine", "petty", "golly", "plait", "fleck", "felon", "gourd", "brown", "thrum", "ficus", "stash", "decry", "wiser", "junta", "visor", "daunt", "scree", "impel", "await", "press", "whose", "turbo", "stoop", "speak", "mangy", "eying", "inlet", "crone", "pulse", "mossy", "staid", "hence", "pinch", "teddy", "sully", "snore", "ripen", "snowy", "attic", "going", "leach", "mouth", "hound", "clump", "tonal", "bigot", "peril", "piece", "blame", "haute", "spied", "undid", "intro", "basal", "shine", "gecko", "rodeo", "guard", "steer", "loamy", "scamp", "scram", "manly", "hello", "vaunt", "organ", "feral", "knock", "extra", "condo", "adapt", "willy", "polka", "rayon", "skirt", "faith", "torso", "match", "mercy", "tepid", "sleek", "riser", "twixt", "peace", "flush", "catty", "login", "eject", "roger", "rival", "untie", "refit", "aorta", "adult", "judge", "rower", "artsy", "rural", "shave", "bobby", "eclat", "fella", "gaily", "harry", "hasty", "hydro", "liege", "octal", "ombre", "payer", "sooth", "unset", "unlit", "vomit", "fanny" };
            Random rnd = new Random();
            int num = rnd.Next(wordList.Count);
            word = wordList[num].ToUpper();
        }

        private void userInput_TextChanged(object sender, EventArgs e)
        {
            
        }
        //Variable that keeps track of the line the user is guessing
        int line = 1;
        //Button that enters the guess
        private void enterBtn_Click(object sender, EventArgs e)
        {
            //Variable to keep track of which line is being guessed
            try
            {
                string answer = userInput.Text.ToUpper();
                //Checks if a user input a number
                if (userInput.Text.Any(char.IsDigit))
                {
                    userInput.Text = userInput.Text.Substring(userInput.Text.Length, userInput.Text.Length - 1);
                }
                //Checks if user put in a 5 letter word
                if (answer.Count() == 5)
                {
                    if (line == 1)
                    {
                        //Label1
                        //If statement to check the character is correct and changes the colour accordingly
                        if (answer.Substring(0, 1) == word.Substring(0, 1))
                        {
                            label1.BackColor = Color.Green;
                            label1.Text = answer.Substring(0, 1);
                            KeyColourGreen(label1.Text);
                        }
                        else if (word.Contains(answer.Substring(0, 1)))
                        {
                            label1.BackColor = Color.Yellow;
                            label1.Text = answer.Substring(0, 1);
                            KeyColourYellow(label1.Text);
                        }
                        else
                        {
                            label1.BackColor = Color.Gray;
                            label1.Text = answer.Substring(0, 1);
                            KeyColourGray(label1.Text);
                        }
                        //Label2
                        if (answer.Substring(1, 1) == word.Substring(1, 1))
                        {
                            label2.BackColor = Color.Green;
                            label2.Text = answer.Substring(1, 1);
                            KeyColourGreen(label2.Text);
                        }
                        else if (word.Contains(answer.Substring(1, 1)))
                        {
                            label2.BackColor = Color.Yellow;
                            label2.Text = answer.Substring(1, 1);
                            KeyColourYellow(label2.Text);
                        }
                        else
                        {
                            label2.BackColor = Color.Gray;
                            label2.Text = answer.Substring(1, 1);
                            KeyColourGray(label2.Text);
                        }
                        //Label3
                        if (answer.Substring(2, 1) == word.Substring(2, 1))
                        {
                            label3.BackColor = Color.Green;
                            label3.Text = answer.Substring(2, 1);
                            KeyColourGreen(label3.Text);
                        }
                        else if (word.Contains(answer.Substring(2, 1)))
                        {
                            label3.BackColor = Color.Yellow;
                            label3.Text = answer.Substring(2, 1);
                            KeyColourYellow(label3.Text);
                        }
                        else
                        {
                            label3.BackColor = Color.Gray;
                            label3.Text = answer.Substring(2, 1);
                            KeyColourGray(label3.Text);
                        }
                        //Label4
                        if (answer.Substring(3, 1) == word.Substring(3, 1))
                        {
                            label4.BackColor = Color.Green;
                            label4.Text = answer.Substring(3, 1);
                            KeyColourGreen(label4.Text);
                        }
                        else if (word.Contains(answer.Substring(3, 1)))
                        {
                            label4.BackColor = Color.Yellow;
                            label4.Text = answer.Substring(3, 1);
                            KeyColourYellow(label4.Text);
                        }
                        else
                        {
                            label4.BackColor = Color.Gray;
                            label4.Text = answer.Substring(3, 1);
                            KeyColourGray(label4.Text);
                        }
                        //Label5
                        if (answer.Substring(4, 1) == word.Substring(4, 1))
                        {
                            label5.BackColor = Color.Green;
                            label5.Text = answer.Substring(4, 1);
                            KeyColourGreen(label5.Text);
                        }
                        else if (word.Contains(answer.Substring(4, 1)))
                        {
                            label5.BackColor = Color.Yellow;
                            label5.Text = answer.Substring(4, 1);
                            KeyColourYellow(label5.Text);
                        }
                        else
                        {
                            label5.BackColor = Color.Gray;
                            label5.Text = answer.Substring(4, 1);
                            KeyColourGray(label5.Text);
                        }
                        line++;
                    }
                    else if (line == 2)
                    {
                        //Label6
                        if (answer.Substring(0, 1) == word.Substring(0, 1))
                        {
                            label6.BackColor = Color.Green;
                            label6.Text = answer.Substring(0, 1);
                            KeyColourGreen(label6.Text);
                        }
                        else if (word.Contains(answer.Substring(0, 1)))
                        {
                            label6.BackColor = Color.Yellow;
                            label6.Text = answer.Substring(0, 1);
                            KeyColourYellow(label6.Text);
                        }
                        else
                        {
                            label6.BackColor = Color.Gray;
                            label6.Text = answer.Substring(0, 1);
                            KeyColourGray(label6.Text);
                        }
                        //Label7
                        if (answer.Substring(1, 1) == word.Substring(1, 1))
                        {
                            label7.BackColor = Color.Green;
                            label7.Text = answer.Substring(1, 1);
                            KeyColourGreen(label7.Text);
                        }
                        else if (word.Contains(answer.Substring(1, 1)))
                        {
                            label7.BackColor = Color.Yellow;
                            label7.Text = answer.Substring(1, 1);
                            KeyColourYellow(label7.Text);
                        }
                        else
                        {
                            label7.BackColor = Color.Gray;
                            label7.Text = answer.Substring(1, 1);
                            KeyColourGray(label7.Text);
                        }
                        //Label8
                        if (answer.Substring(2, 1) == word.Substring(2, 1))
                        {
                            label8.BackColor = Color.Green;
                            label8.Text = answer.Substring(2, 1);
                            KeyColourGreen(label8.Text);
                        }
                        else if (word.Contains(answer.Substring(2, 1)))
                        {
                            label8.BackColor = Color.Yellow;
                            label8.Text = answer.Substring(2, 1);
                            KeyColourYellow(label8.Text);
                        }
                        else
                        {
                            label8.BackColor = Color.Gray;
                            label8.Text = answer.Substring(2, 1);
                            KeyColourGray(label8.Text);
                        }
                        //Label9
                        if (answer.Substring(3, 1) == word.Substring(3, 1))
                        {
                            label9.BackColor = Color.Green;
                            label9.Text = answer.Substring(3, 1);
                            KeyColourGreen(label9.Text);
                        }
                        else if (word.Contains(answer.Substring(3, 1)))
                        {
                            label9.BackColor = Color.Yellow;
                            label9.Text = answer.Substring(3, 1);
                            KeyColourYellow(label9.Text);
                        }
                        else
                        {
                            label9.BackColor = Color.Gray;
                            label9.Text = answer.Substring(3, 1);
                            KeyColourGray(label9.Text);
                        }
                        //Label10
                        if (answer.Substring(4, 1) == word.Substring(4, 1))
                        {
                            label10.BackColor = Color.Green;
                            label10.Text = answer.Substring(4, 1);
                            KeyColourGreen(label10.Text);
                        }
                        else if (word.Contains(answer.Substring(4, 1)))
                        {
                            label10.BackColor = Color.Yellow;
                            label10.Text = answer.Substring(4, 1);
                            KeyColourYellow(label10.Text);
                        }
                        else
                        {
                            label10.BackColor = Color.Gray;
                            label10.Text = answer.Substring(4, 1);
                            KeyColourGray(label10.Text);
                        }
                        line++;
                    }
                    else if (line == 3)
                    {
                        //Label11
                        if (answer.Substring(0, 1) == word.Substring(0, 1))
                        {
                            label11.BackColor = Color.Green;
                            label11.Text = answer.Substring(0, 1);
                            KeyColourGreen(label11.Text);
                        }
                        else if (word.Contains(answer.Substring(0, 1)))
                        {
                            label11.BackColor = Color.Yellow;
                            label11.Text = answer.Substring(0, 1);
                            KeyColourYellow(label11.Text);
                        }
                        else
                        {
                            label11.BackColor = Color.Gray;
                            label11.Text = answer.Substring(0, 1);
                            KeyColourGray(label11.Text);
                        }
                        //Label12
                        if (answer.Substring(1, 1) == word.Substring(1, 1))
                        {
                            label12.BackColor = Color.Green;
                            label12.Text = answer.Substring(1, 1);
                            KeyColourGreen(label12.Text);
                        }
                        else if (word.Contains(answer.Substring(1, 1)))
                        {
                            label12.BackColor = Color.Yellow;
                            label12.Text = answer.Substring(1, 1);
                            KeyColourYellow(label12.Text);
                        }
                        else
                        {
                            label12.BackColor = Color.Gray;
                            label12.Text = answer.Substring(1, 1);
                            KeyColourGray(label12.Text);
                        }
                        //Label13
                        if (answer.Substring(2, 1) == word.Substring(2, 1))
                        {
                            label13.BackColor = Color.Green;
                            label13.Text = answer.Substring(2, 1);
                            KeyColourGreen(label13.Text);
                        }
                        else if (word.Contains(answer.Substring(2, 1)))
                        {
                            label13.BackColor = Color.Yellow;
                            label13.Text = answer.Substring(2, 1);
                            KeyColourYellow(label13.Text);
                        }
                        else
                        {
                            label13.BackColor = Color.Gray;
                            label13.Text = answer.Substring(2, 1);
                            KeyColourGray(label13.Text);
                        }
                        //Label14
                        if (answer.Substring(3, 1) == word.Substring(3, 1))
                        {
                            label14.BackColor = Color.Green;
                            label14.Text = answer.Substring(3, 1);
                            KeyColourGreen(label14.Text);
                        }
                        else if (word.Contains(answer.Substring(3, 1)))
                        {
                            label14.BackColor = Color.Yellow;
                            label14.Text = answer.Substring(3, 1);
                            KeyColourYellow(label14.Text);
                        }
                        else
                        {
                            label14.BackColor = Color.Gray;
                            label14.Text = answer.Substring(3, 1);
                            KeyColourGray(label14.Text);
                        }
                        //Label15
                        if (answer.Substring(4, 1) == word.Substring(4, 1))
                        {
                            label15.BackColor = Color.Green;
                            label15.Text = answer.Substring(4, 1);
                            KeyColourGreen(label15.Text);
                        }
                        else if (word.Contains(answer.Substring(4, 1)))
                        {
                            label15.BackColor = Color.Yellow;
                            label15.Text = answer.Substring(4, 1);
                            KeyColourYellow(label15.Text);
                        }
                        else
                        {
                            label15.BackColor = Color.Gray;
                            label15.Text = answer.Substring(4, 1);
                            KeyColourGray(label15.Text);
                        }
                        line++;

                    }
                    else if (line == 4)
                    {
                        //Label16
                        if (answer.Substring(0, 1) == word.Substring(0, 1))
                        {
                            label16.BackColor = Color.Green;
                            label16.Text = answer.Substring(0, 1);
                            KeyColourGreen(label16.Text);
                        }
                        else if (word.Contains(answer.Substring(0, 1)))
                        {
                            label16.BackColor = Color.Yellow;
                            label16.Text = answer.Substring(0, 1);
                            KeyColourYellow(label16.Text);
                        }
                        else
                        {
                            label16.BackColor = Color.Gray;
                            label16.Text = answer.Substring(0, 1);
                            KeyColourGray(label16.Text);
                        }
                        //Label17
                        if (answer.Substring(1, 1) == word.Substring(1, 1))
                        {
                            label17.BackColor = Color.Green;
                            label17.Text = answer.Substring(1, 1);
                            KeyColourGreen(label17.Text);
                        }
                        else if (word.Contains(answer.Substring(1, 1)))
                        {
                            label17.BackColor = Color.Yellow;
                            label17.Text = answer.Substring(1, 1);
                            KeyColourYellow(label17.Text);
                        }
                        else
                        {
                            label17.BackColor = Color.Gray;
                            label17.Text = answer.Substring(1, 1);
                            KeyColourGray(label17.Text);
                        }
                        //Label18
                        if (answer.Substring(2, 1) == word.Substring(2, 1))
                        {
                            label18.BackColor = Color.Green;
                            label18.Text = answer.Substring(2, 1);
                            KeyColourGreen(label18.Text);
                        }
                        else if (word.Contains(answer.Substring(2, 1)))
                        {
                            label18.BackColor = Color.Yellow;
                            label18.Text = answer.Substring(2, 1);
                            KeyColourYellow(label18.Text);
                        }
                        else
                        {
                            label18.BackColor = Color.Gray;
                            label18.Text = answer.Substring(2, 1);
                            KeyColourGray(label18.Text);
                        }
                        //Label19
                        if (answer.Substring(3, 1) == word.Substring(3, 1))
                        {
                            label19.BackColor = Color.Green;
                            label19.Text = answer.Substring(3, 1);
                            KeyColourGreen(label19.Text);
                        }
                        else if (word.Contains(answer.Substring(3, 1)))
                        {
                            label19.BackColor = Color.Yellow;
                            label19.Text = answer.Substring(3, 1);
                            KeyColourYellow(label19.Text);
                        }
                        else
                        {
                            label19.BackColor = Color.Gray;
                            label19.Text = answer.Substring(3, 1);
                            KeyColourGray(label19.Text);
                        }
                        //Label20
                        if (answer.Substring(4, 1) == word.Substring(4, 1))
                        {
                            label20.BackColor = Color.Green;
                            label20.Text = answer.Substring(4, 1);
                            KeyColourGreen(label20.Text);
                        }
                        else if (word.Contains(answer.Substring(4, 1)))
                        {
                            label20.BackColor = Color.Yellow;
                            label20.Text = answer.Substring(4, 1);
                            KeyColourYellow(label20.Text);
                        }
                        else
                        {
                            label20.BackColor = Color.Gray;
                            label20.Text = answer.Substring(4, 1);
                            KeyColourGray(label20.Text);
                        }
                        line++;
                    }
                    else if (line == 5)
                    {
                        //Label21
                        if (answer.Substring(0, 1) == word.Substring(0, 1))
                        {
                            label21.BackColor = Color.Green;
                            label21.Text = answer.Substring(0, 1);
                            KeyColourGreen(label21.Text);
                        }
                        else if (word.Contains(answer.Substring(0, 1)))
                        {
                            label21.BackColor = Color.Yellow;
                            label21.Text = answer.Substring(0, 1);
                            KeyColourYellow(label21.Text);
                        }
                        else
                        {
                            label21.BackColor = Color.Gray;
                            label21.Text = answer.Substring(0, 1);
                            KeyColourGray(label21.Text);
                        }
                        //Label22
                        if (answer.Substring(1, 1) == word.Substring(1, 1))
                        {
                            label22.BackColor = Color.Green;
                            label22.Text = answer.Substring(1, 1);
                            KeyColourGreen(label22.Text);
                        }
                        else if (word.Contains(answer.Substring(1, 1)))
                        {
                            label22.BackColor = Color.Yellow;
                            label22.Text = answer.Substring(1, 1);
                            KeyColourYellow(label22.Text);
                        }
                        else
                        {
                            label22.BackColor = Color.Gray;
                            label22.Text = answer.Substring(1, 1);
                            KeyColourGray(label22.Text);
                        }
                        //Label23
                        if (answer.Substring(2, 1) == word.Substring(2, 1))
                        {
                            label23.BackColor = Color.Green;
                            label23.Text = answer.Substring(2, 1);
                            KeyColourGreen(label23.Text);
                        }
                        else if (word.Contains(answer.Substring(2, 1)))
                        {
                            label23.BackColor = Color.Yellow;
                            label23.Text = answer.Substring(2, 1);
                            KeyColourYellow(label23.Text);
                        }
                        else
                        {
                            label23.BackColor = Color.Gray;
                            label23.Text = answer.Substring(2, 1);
                            KeyColourGray(label23.Text);
                        }
                        //Label24
                        if (answer.Substring(3, 1) == word.Substring(3, 1))
                        {
                            label24.BackColor = Color.Green;
                            label24.Text = answer.Substring(3, 1);
                            KeyColourGreen(label24.Text);
                        }
                        else if (word.Contains(answer.Substring(3, 1)))
                        {
                            label24.BackColor = Color.Yellow;
                            label24.Text = answer.Substring(3, 1);
                            KeyColourYellow(label24.Text);
                        }
                        else
                        {
                            label24.BackColor = Color.Gray;
                            label24.Text = answer.Substring(3, 1);
                            KeyColourGray(label24.Text);
                        }
                        //Label25
                        if (answer.Substring(4, 1) == word.Substring(4, 1))
                        {
                            label25.BackColor = Color.Green;
                            label25.Text = answer.Substring(4, 1);
                            KeyColourGreen(label25.Text);
                        }
                        else if (word.Contains(answer.Substring(4, 1)))
                        {
                            label25.BackColor = Color.Yellow;
                            label25.Text = answer.Substring(4, 1);
                            KeyColourYellow(label25.Text);
                        }
                        else
                        {
                            label25.BackColor = Color.Gray;
                            label25.Text = answer.Substring(4, 1);
                            KeyColourGray(label25.Text);
                        }
                        //If the user never guessed the word
                        if (answer != word)
                        {
                            MessageBox.Show($"Sorry, the correct word was \"{word.ToLower()}\"");
                        }
                    }
                    //If solved display message
                    if (answer == word)
                    {
                        MessageBox.Show($"Congratulations, you got the word! It was \"{word.ToLower()}\"", "Winner!", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    //If the user doesn't put in 5 letters
                    MessageBox.Show("Please input a 5 letter word", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    userInput.Text = "";
                }
                //Clears textbox after every entry
                userInput.Text = "";
            }
            catch
            {
                //If the user doesn't put in 5 letters
                MessageBox.Show("Please input a 5 letter word", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userInput.Text = "";
            }
        }
        
        //Backspace button
        private void Backspace_Click(object sender, EventArgs e)
        {
            //Deletes the last character from the textbox
            if (userInput.Text.Count() != 0)
            {
                    userInput.Text = userInput.Text.Substring(0, userInput.Text.Length - 1);
            }
        }

        //Next blocks are purely for keyboard button input

        //Method that adds the letter to the textbox
        private void Keyboard(string letter)
        {
            if (userInput.Text.Count() != 5)
            {
                userInput.Text += letter;
            }
        }
        //Method that changes the colour of the button to green
        private void KeyColourGreen(string letter)
        {
            if(letter == "Q")
            {
                Q.BackColor = Color.Green;
            }
            else if (letter == "W")
            {
                W.BackColor = Color.Green;
            }
            else if (letter == "E")
            {
                E.BackColor = Color.Green;
            }
            else if (letter == "R")
            {
                R.BackColor = Color.Green;
            }
            else if (letter == "T")
            {
                T.BackColor = Color.Green;
            }
            else if (letter == "Y")
            {
                Y.BackColor = Color.Green;
            }
            else if (letter == "U")
            {
                U.BackColor = Color.Green;
            }
            else if (letter == "I")
            {
                I.BackColor = Color.Green;
            }
            else if (letter == "O")
            {
                O.BackColor = Color.Green;
            }
            else if (letter == "P")
            {
                P.BackColor = Color.Green;
            }
            else if (letter == "A")
            {
                A.BackColor = Color.Green;
            }
            else if (letter == "S")
            {
                S.BackColor = Color.Green;
            }
            else if (letter == "D")
            {
                D.BackColor = Color.Green;
            }
            else if (letter == "F")
            {
                F.BackColor = Color.Green;
            }
            else if (letter == "G")
            {
                G.BackColor = Color.Green;
            }
            else if (letter == "H")
            {
                H.BackColor = Color.Green;
            }
            else if (letter == "J")
            {
                J.BackColor = Color.Green;
            }
            else if (letter == "K")
            {
                K.BackColor = Color.Green;
            }
            else if (letter == "L")
            {
                L.BackColor = Color.Green;
            }
            else if (letter == "Z")
            {
                Z.BackColor = Color.Green;
            }
            else if (letter == "X")
            {
                X.BackColor = Color.Green;
            }
            else if (letter == "C")
            {
                C.BackColor = Color.Green;
            }
            else if (letter == "V")
            {
                V.BackColor = Color.Green;
            }
            else if (letter == "B")
            {
                B.BackColor = Color.Green;
            }
            else if (letter == "N")
            {
                N.BackColor = Color.Green;
            }
            else if (letter == "M")
            {
                M.BackColor = Color.Green;
            }
        }
        //Method that changes the colour of the button to yellow, if it's not green
        private void KeyColourYellow(string letter)
        {
            if (letter == "Q")
            {
                if(Q.BackColor != Color.Green)
                {
                    Q.BackColor = Color.Yellow;
                }
            }
            else if (letter == "W")
            {
                if (W.BackColor != Color.Green)
                {
                    W.BackColor = Color.Yellow;
                }
            }
            else if (letter == "E")
            {
                if (E.BackColor != Color.Green)
                {
                    E.BackColor = Color.Yellow;
                }
            }
            else if (letter == "R")
            {
                if (R.BackColor != Color.Green)
                {
                    R.BackColor = Color.Yellow;
                }
            }
            else if (letter == "T")
            {
                if (T.BackColor != Color.Green)
                {
                    T.BackColor = Color.Yellow;
                }
            }
            else if (letter == "Y")
            {
                if (Y.BackColor != Color.Green)
                {
                    Y.BackColor = Color.Yellow;
                }
            }
            else if (letter == "U")
            {
                if (U.BackColor != Color.Green)
                {
                    U.BackColor = Color.Yellow;
                }
            }
            else if (letter == "I")
            {
                if (I.BackColor != Color.Green)
                {
                    I.BackColor = Color.Yellow;
                }
            }
            else if (letter == "O")
            {
                if (O.BackColor != Color.Green)
                {
                    O.BackColor = Color.Yellow;
                }
            }
            else if (letter == "P")
            {
                if (P.BackColor != Color.Green)
                {
                    P.BackColor = Color.Yellow;
                }
            }
            else if (letter == "A")
            {
                if (A.BackColor != Color.Green)
                {
                    A.BackColor = Color.Yellow;
                }
            }
            else if (letter == "S")
            {
                if (S.BackColor != Color.Green)
                {
                    S.BackColor = Color.Yellow;
                }
            }
            else if (letter == "D")
            {
                if (D.BackColor != Color.Green)
                {
                    D.BackColor = Color.Yellow;
                }
            }
            else if (letter == "F")
            {
                if (F.BackColor != Color.Green)
                {
                    F.BackColor = Color.Yellow;
                }
            }
            else if (letter == "G")
            {
                if (G.BackColor != Color.Green)
                {
                    G.BackColor = Color.Yellow;
                }
            }
            else if (letter == "H")
            {
                if (H.BackColor != Color.Green)
                {
                    H.BackColor = Color.Yellow;
                }
            }
            else if (letter == "J")
            {
                if (J.BackColor != Color.Green)
                {
                    J.BackColor = Color.Yellow;
                }
            }
            else if (letter == "K")
            {
                if (K.BackColor != Color.Green)
                {
                    K.BackColor = Color.Yellow;
                }
            }
            else if (letter == "L")
            {
                if (L.BackColor != Color.Green)
                {
                    L.BackColor = Color.Yellow;
                }
            }
            else if (letter == "Z")
            {
                if (Z.BackColor != Color.Green)
                {
                    Z.BackColor = Color.Yellow;
                }
            }
            else if (letter == "X")
            {
                if (X.BackColor != Color.Green)
                {
                    X.BackColor = Color.Yellow;
                }
            }
            else if (letter == "C")
            {
                if (C.BackColor != Color.Green)
                {
                    C.BackColor = Color.Yellow;
                }
            }
            else if (letter == "V")
            {
                if (V.BackColor != Color.Green)
                {
                    V.BackColor = Color.Yellow;
                }
            }
            else if (letter == "B")
            {
                if (B.BackColor != Color.Green)
                {
                    B.BackColor = Color.Yellow;
                }
            }
            else if (letter == "N")
            {
                if (N.BackColor != Color.Green)
                {
                    N.BackColor = Color.Yellow;
                }
            }
            else if (letter == "M")
            {
                if (M.BackColor != Color.Green)
                {
                    M.BackColor = Color.Yellow;
                }
            }

        }
        //Method that changes the colour of the button to gray
        private void KeyColourGray(string letter)
        {
            if (letter == "Q")
            {
                Q.BackColor = Color.Gray;
            }
            else if (letter == "W")
            {
                W.BackColor = Color.Gray;
            }
            else if (letter == "E")
            {
                E.BackColor = Color.Gray;
            }
            else if (letter == "R")
            {
                R.BackColor = Color.Gray;
            }
            else if (letter == "T")
            {
                T.BackColor = Color.Gray;
            }
            else if (letter == "Y")
            {
                Y.BackColor = Color.Gray;
            }
            else if (letter == "U")
            {
                U.BackColor = Color.Gray;
            }
            else if (letter == "I")
            {
                I.BackColor = Color.Gray;
            }
            else if (letter == "O")
            {
                O.BackColor = Color.Gray;
            }
            else if (letter == "P")
            {
                P.BackColor = Color.Gray;
            }
            else if (letter == "A")
            {
                A.BackColor = Color.Gray;
            }
            else if (letter == "S")
            {
                S.BackColor = Color.Gray;
            }
            else if (letter == "D")
            {
                D.BackColor = Color.Gray;
            }
            else if (letter == "F")
            {
                F.BackColor = Color.Gray;
            }
            else if (letter == "G")
            {
                G.BackColor = Color.Gray;
            }
            else if (letter == "H")
            {
                H.BackColor = Color.Gray;
            }
            else if (letter == "J")
            {
                J.BackColor = Color.Gray;
            }
            else if (letter == "K")
            {
                K.BackColor = Color.Gray;
            }
            else if (letter == "L")
            {
                L.BackColor = Color.Gray;
            }
            else if (letter == "Z")
            {
                Z.BackColor = Color.Gray;
            }
            else if (letter == "X")
            {
                X.BackColor = Color.Gray;
            }
            else if (letter == "C")
            {
                C.BackColor = Color.Gray;
            }
            else if (letter == "V")
            {
                V.BackColor = Color.Gray;
            }
            else if (letter == "B")
            {
                B.BackColor = Color.Gray;
            }
            else if (letter == "N")
            {
                N.BackColor = Color.Gray;
            }
            else if (letter == "M")
            {
                M.BackColor = Color.Gray;
            }
        }

        //Buttons that call a method when clicked
        private void Q_Click(object sender, EventArgs e)
        {
            Keyboard(Q.Text);
        }

        private void W_Click(object sender, EventArgs e)
        {
            Keyboard(W.Text);
        }

        private void E_Click(object sender, EventArgs e)
        {
            Keyboard(E.Text);
        }

        private void R_Click(object sender, EventArgs e)
        {
            Keyboard(R.Text);
        }

        private void T_Click(object sender, EventArgs e)
        {
            Keyboard(T.Text);
        }

        private void Y_Click(object sender, EventArgs e)
        {
            Keyboard(Y.Text);
        }

        private void U_Click(object sender, EventArgs e)
        {
            Keyboard(U.Text);
        }

        private void I_Click(object sender, EventArgs e)
        {
            Keyboard(I.Text);
        }

        private void O_Click(object sender, EventArgs e)
        {
            Keyboard(O.Text);
        }

        private void P_Click(object sender, EventArgs e)
        {
            Keyboard(P.Text);
        }

        private void A_Click(object sender, EventArgs e)
        {
            Keyboard(A.Text);
        }

        private void S_Click(object sender, EventArgs e)
        {
            Keyboard(S.Text);
        }

        private void D_Click(object sender, EventArgs e)
        {
            Keyboard(D.Text);
        }

        private void F_Click(object sender, EventArgs e)
        {
            Keyboard(F.Text);
        }

        private void G_Click(object sender, EventArgs e)
        {
            Keyboard(G.Text);
        }

        private void H_Click(object sender, EventArgs e)
        {
            Keyboard(H.Text);
        }

        private void J_Click(object sender, EventArgs e)
        {
            Keyboard(J.Text);
        }

        private void K_Click(object sender, EventArgs e)
        {
            Keyboard(K.Text);
        }

        private void L_Click(object sender, EventArgs e)
        {
            Keyboard(L.Text);
        }

        private void Z_Click(object sender, EventArgs e)
        {
            Keyboard(Z.Text);
        }

        private void X_Click(object sender, EventArgs e)
        {
            Keyboard(X.Text);
        }

        private void C_Click(object sender, EventArgs e)
        {
            Keyboard(C.Text);
        }

        private void V_Click(object sender, EventArgs e)
        {
            Keyboard(V.Text);
        }

        private void B_Click(object sender, EventArgs e)
        {
            Keyboard(B.Text);
        }

        private void N_Click(object sender, EventArgs e)
        {
            Keyboard(N.Text);
        }

        private void M_Click(object sender, EventArgs e)
        {
            Keyboard(M.Text);
        }
        //Clears all the guesses(but keeps your guessed letters)
        private void restartBtn_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.DarkGray;
            label1.Text = "_";
            label2.BackColor = Color.DarkGray;
            label2.Text = "_";
            label3.BackColor = Color.DarkGray;
            label3.Text = "_";
            label4.BackColor = Color.DarkGray;
            label4.Text = "_";
            label5.BackColor = Color.DarkGray;
            label5.Text = "_";
            label6.BackColor = Color.DarkGray;
            label6.Text = "_";
            label7.BackColor = Color.DarkGray;
            label7.Text = "_";
            label8.BackColor = Color.DarkGray;
            label8.Text = "_";
            label9.BackColor = Color.DarkGray;
            label9.Text = "_";
            label10.BackColor = Color.DarkGray;
            label10.Text = "_";
            label11.BackColor = Color.DarkGray;
            label11.Text = "_";
            label12.BackColor = Color.DarkGray;
            label12.Text = "_";
            label13.BackColor = Color.DarkGray;
            label13.Text = "_";
            label14.BackColor = Color.DarkGray;
            label14.Text = "_";
            label15.BackColor = Color.DarkGray;
            label15.Text = "_";
            label16.BackColor = Color.DarkGray;
            label16.Text = "_";
            label17.BackColor = Color.DarkGray;
            label17.Text = "_";
            label18.BackColor = Color.DarkGray;
            label18.Text = "_";
            label19.BackColor = Color.DarkGray;
            label19.Text = "_";
            label20.BackColor = Color.DarkGray;
            label20.Text = "_";
            label21.BackColor = Color.DarkGray;
            label21.Text = "_";
            label22.BackColor = Color.DarkGray;
            label22.Text = "_";
            label23.BackColor = Color.DarkGray;
            label23.Text = "_";
            label24.BackColor = Color.DarkGray;
            label24.Text = "_";
            label25.BackColor = Color.DarkGray;
            label25.Text = "_";
            line = 1;
        }
        //Refreshes application to get a new word
        private void newBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}