# DodgeBall - Copilot AI Coding Instructions

## Project Overview
DodgeBall is a 2D Unity game project using Universal Render Pipeline. The architecture follows a component-based design pattern with a player state machine for managing game states.

## Architecture & Core Patterns

### Component-Based Design
- **Config ScriptableObjects** (`Assets/Config/`): Store runtime configuration data
  - `Movement.cs`: Player movement speed settings
  - `Dash.cs`: Dash mechanics (cooldown, time, speed)
  - `AttackConfig.cs`: Attack properties (bullet force, size, lifetime)
  - `Health.cs`: Health configuration
  - Created via `[CreateAssetMenu]` for inspector management

- **Core Components** (`Assets/Scripts/Components/`):
  - `HealthComponent`: Implements `IDamageable` interface; manages entity health/death
  - `AttackComponent`: Manages obstacle attacks (incomplete - needs firepoints implementation)

### Player State Machine Pattern
Located in `Assets/Scripts/Player/PlayerStateMachine/`:
- **Base Classes**:
  - `PlayerState`: Abstract base with lifecycle methods (`EnterState()`, `ExitState()`, `FrameUpdate()`, `PhysicsUpdate()`, `AnimationTriggerEvent()`)
  - `PlayerStateMachine`: Simple state manager holding `CurrentPlayerState`

- **Concrete States**:
  - `DefaultState`: Normal player movement/idle
  - `DashState`: Active dash state (receives `dashConfig` on construction)

- **Integration**: `Player.cs` initializes state machine in `Awake()`, routes `Update()` to `FrameUpdate()` and `FixedUpdate()` to `PhysicsUpdate()`

### Input System
- Uses **new Input System** (see `PlayerInput.inputactions` and `UnityEngine.InputSystem`)
- `PlayerMovement.cs` handles input binding and physics-based movement
- Movement can be locked via `lockMovement` boolean (used during dash state)

### Damage/Health System
- **Interface-driven**: `IDamageable` defines `Damage(float)`, `Die()`, and health properties
- `HealthComponent` implements this and handles death logic (currently logs "Dead")
- States can integrate damage by checking component implementation

## Key Files & Their Roles

| File | Purpose |
|------|---------|
| [Assets/Scripts/Player/Player.cs](Assets/Scripts/Player/Player.cs) | Master player controller; state machine owner |
| [Assets/Scripts/Player/PlayerMovement.cs](Assets/Scripts/Player/PlayerMovement.cs) | Input handling & physics-based movement |
| [Assets/Scripts/Components/HealthComponent.cs](Assets/Scripts/Components/HealthComponent.cs) | Health system & damage interface |
| [Assets/Config/](Assets/Config/) | Configuration ScriptableObjects (separate from gameplay code) |

## Coding Conventions

1. **Config Pattern**: Always externalize numeric/gameplay values to `[CreateAssetMenu]` ScriptableObjects in `Assets/Config/`
2. **Component Dependencies**: Use `public` fields for references (e.g., `public Player player`, `public Rigidbody2D rb`)
3. **State Lifecycle**: Always implement EnterState/ExitState pairs for setup/cleanup
4. **Physics**: Use `FixedUpdate()` for physics via `PhysicsUpdate()` state method; `Update()` for input via `FrameUpdate()`
5. **Interfaces**: Use `IDamageable` pattern for systems that multiple entities need (damage, health, death)

## Common Workflows

### Adding a New Player State
1. Create `Assets/Scripts/Player/PlayerStateMachine/States/YourState.cs` inheriting from `PlayerState`
2. Initialize and register in `Player.Awake()` (public property + constructor call)
3. Transition via `psm.ChangeState(newState)` from input or conditions
4. Use config ScriptableObjects for tuneable values

### Adding Component Behavior
1. Create script in `Assets/Scripts/Components/` or `Assets/Scripts/Components/Obstacles/`
2. Inherit from `MonoBehaviour` and reference needed configs
3. For damage mechanics: implement `IDamageable` interface
4. Use `Awake()` for init from config, `Start()` for scene setup

### Tuning Values
- Never hardcode gameplay numbers; create or extend a config ScriptableObject
- Right-click → Create Asset → Config/[Type] to create instances in Inspector

## Project Structure
```
Assets/
├── Scripts/
│   ├── Player/
│   │   ├── Player.cs
│   │   ├── PlayerMovement.cs
│   │   └── PlayerStateMachine/
│   │       ├── PlayerState.cs (abstract)
│   │       ├── PlayerStateMachine.cs
│   │       └── States/
│   ├── Components/
│   │   ├── HealthComponent.cs
│   │   └── Obstacles/
│   │       └── AttackComponent.cs
│   └── Interfaces/
│       └── IDamageable.cs
└── Config/
    ├── Movement.cs
    ├── Dash.cs
    ├── Health.cs
    └── AttackConfig.cs
```

## Notes for AI Agents
- This codebase is **early stage**; many systems are scaffolded (e.g., `AttackComponent` incomplete)
- Focus on **consistency** with existing patterns (state machine, config objects, component interfaces)
- Use `Debug.Log()` for current logging (e.g., death state)
- When implementing new features, ask: "Does this need a ScriptableObject config?"
