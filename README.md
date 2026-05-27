# retroLib

A C# utility library for game development, featuring fakers, collections, casting helpers, and gameplay systems.

---

## Installation

Clone the repository and add the project reference to your solution:

```xml
<ProjectReference Include="..\retroLib\retroLib.csproj" />
```

---

## LootPool\<T\>

Weighted random picker with pity system.

```csharp
var loot = new LootPool<string>()
    .Add("Common Sword",    weight: 60)
    .Add("Rare Shield",     weight: 25)
    .Add("Legendary Armor", weight: 5, isRare: true, pityThreshold: 10);

string item = loot.Roll();
List<string> drops = loot.RollMany(3);
List<string> unique = loot.RollWithoutReplacement(2);
```

| Method | Description |
|---|---|
| `Roll()` | Pick one item based on weights |
| `RollMany(n)` | Pick n items |
| `RollWithoutReplacement(n)` | Pick n unique items |

---

## Casting

Safe casting and conversion extension methods.

```csharp
// TryCast
myObj.TryCast<Enemy>(out var enemy);

// CastOrNull
Enemy? e = myObj.CastOrNull<Enemy>();

// CastOrDefault
Enemy e2 = myObj.CastOrDefault<Enemy>(new DefaultEnemy());

// ParseOrDefault
int hp = "150".ParseOrDefault<int>(0);
```

---

## Faker

Generate realistic placeholder data.

### FakerBuilder — full object
```csharp
FakerPerson person = FakerBuilder.Person();

Console.WriteLine(person.FullName);  // "Michael Garcia"
Console.WriteLine(person.Email);     // "m.garcia42@gmail.com"
Console.WriteLine(person.Address);   // "84 Oak Avenue, Tokyo"
Console.WriteLine(person.Age);       // 34
Console.WriteLine(person.Gender);    // "Male"
Console.WriteLine(person.Phone);     // "+44 312 876 4521"
```

### Faker — pick values on the fly
```csharp
Faker.Name.FirstName();       // "Sarah"
Faker.Name.FullName();        // "Sarah Williams"
Faker.Internet.Email();       // "s.williams@gmail.com"
Faker.Address.City();         // "Tokyo"
Faker.Address.Country();      // "Japan"
Faker.Person.Age();           // 27
Faker.Person.Gender();        // "Female"
Faker.Person.Phone();         // "+7 543 210 9876"
```

---

## Cooldown

```csharp
var cd = new Cooldown(1.5f);
cd.OnReady += () => Debug.Log("Ready!");

void Update()
{
    cd.Tick(Time.deltaTime);

    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (cd.Use())
            Attack();
        else
            Debug.Log($"Wait {cd.Remaining:F1}s");
    }
}
```

| Property/Method | Description |
|---|---|
| `IsReady` | True if cooldown is over |
| `Remaining` | Time left in seconds |
| `Progress` | 0 to 1 fill value |
| `Use()` | Trigger the cooldown, returns false if not ready |
| `Reset()` | Cancel the cooldown |
| `OnReady` | Event fired when cooldown ends |

---

## GameTimer

```csharp
var timer = new GameTimer(10f, loop: false);
timer.OnComplete += () => Debug.Log("Time's up!");
timer.OnTick += t => Debug.Log($"Remaining: {t:F1}s");
timer.Start();

void Update()
{
    timer.Tick(Time.deltaTime);
}
```

| Property/Method | Description |
|---|---|
| `IsFinished` | True when timer hits 0 |
| `Remaining` | Time left in seconds |
| `Progress` | 0 to 1 fill value |
| `Start()` | Start or restart the timer |
| `Stop()` / `Resume()` | Pause and resume |
| `OnComplete` | Event fired on completion |
| `OnTick` | Event fired every tick with remaining time |

---

## ToroidalMap\<T\> *(coming soon)*

---

## Namespace Overview

| Namespace | Classes |
|---|---|
| `retroLib.Casting` | `CastExtensions` |
| `retroLib.Collections` | `LootPool<T>` |
| `retroLib.Faker` | `Faker`, `FakerBuilder`, `FakerPerson` |
| `retroLib.Faker.Data` | `NamesData`, `PlacesData` |
| `retroLib.GameDev` | `Cooldown`, `GameTimer` |

---

## License

MIT — free to use in personal and commercial projects.
