<p align="center">
  <img src="IceFebruaryLogo.png" alt="IceFebruary Logo" width="500">
</p>

## 🧊 IceFebruary

IceFebruary is a standalone, lightweight, and high-performance architectural framework written in pure C# (POCO). It is meticulously engineered around Clean Architecture principles, completely separating business logic, deterministic mathematics, spatial evaluations, and system states from any backend simulation platform or graphic rendering layer.
The framework is completely self-contained with zero external package overhead. It provides an elegant, platform-agnostic blueprint that utilizes an advanced component-based architecture, allowing it to remain highly flexible. While its structures handle common layout, physics-like queries, and animation pipelines, it is designed to operate in any standard C# runtime—from headless authoritative game servers to modern standalone desktop applications.
Integration with external visual visualization tools or specific processing environments is achieved through a dedicated bridge layer via decoupled automatic proxy generation.

------------------------------

## ✨ Key Strengths & Philosophy

* Absolute Isolation: By containing logic strictly within standard C#, the codebase becomes inherently unit-testable, secure from external API updates, and ready for clean multi-platform distribution.
* Rigid Determinism: Custom implementations of updates, global/local clocks, and pseudo-random number generators guarantee a 100% reproducible execution state. This makes it ideal for lockstep networking, state-synchronization, and reliable replay systems.
* Zero-Alloc Target: Critical mathematical operations, collection modifications, and environmental checks are fully optimized to bypass runtime Garbage Collector allocation spikes. Performance-heavy methods are aggressively decorated with [MethodImpl(MethodImplOptions.AggressiveInlining)].
* Spatial Decoupling via Strategy Pattern: Abstract providers wrap coordinates and rotational properties, enabling real-time logic systems to query or track dynamic targets without knowing their underlying data sources.

------------------------------

## 🛠 Architectural Modules

## 1. Entity Lifecycle

Instead of binding logic execution to heavy, framework-dependent controller objects, IceFebruary manages objects through isolated abstractions:

* IBaseEntity / BaseEntity: Controls the fundamental state machine of every logistically active object via Enabled and Destroyed flags, backed by a deterministic Destroy() cleanup method.
* Exists() Utility: An optimized extension method that provides rapid validation of whether an object is initialized and not flagged for deletion, avoiding external overhead.
* Trigger: A dedicated state flag that stays active for exactly one physical tick step (IFixedFrame), automatically resetting its charge on the subsequent cycle.

## 2. High-Performance Containers (IceFebruary.Collections)

A dedicated collection structure is included to circumvent frequent runtime array allocations:

* EntityFastArray<T>: Maintains an internal stack of available memory slots (_freeIndexes). When an entity is destroyed, its position is immediately recycled. If the container reaches capacity, it performs a lazy self-cleaning swipe. If it remains full, it expands its layout size by a fast bitwise left-shift operation (Length << 1), preventing frequent memory fragmentation.

## 3. Spatial Algebra & Trigonometry (IceFebruary.Space)

The framework hosts its own custom, engine-independent 2D mathematical pipeline:

* Vector2: An immutable two-dimensional structural representation. It features orientation constants (TopRight, BottomLeft, etc.) and non-crashing normalization logic (defaults to Right if length falls below epsilon). Its hashing algorithm utilizes inverse epsilon multipliers to prevent floating-point inaccuracy artifacts.
* Rotor2: Replaces cumbersome and heavy 3D quaternion structures or inaccurate Euler angles with pure 2D geometric algebra (Scalar + XY bivector). Rotor2.Lerp dynamically evaluates the shortest angular trajectory path, naturally eliminating "twisting" behaviors near 180-degree turnarounds.
* ITargetPossessing<T>: A standardized interface for any autonomous runtime routine capable of locking onto or following a specific target provider strategy.

## 4. Evaluation Providers (IceFebruary.Space.*Provider)

Spatial evaluations use a polymorphic Strategy Pattern to keep layout coordinates fluid and unbound:

* IVector2Provider / IRotor2Provider: Contracts designed to evaluate or calculate positions and rotors on demand via a standard TryGet method. Extensions provide a uniform TryGetSafety layout check to smoothly fallback to default values on missing dependencies.
* Structural Decorators: Out-of-the-box variations allow real-time transformations such as static points (Vector2Provider), live attachment tracking (TransformVector2Provider), automated mathematical scaling (ScaleVector2Provider), or directional orientation generation between two dynamic positions (DirectionRotor2Provider).

## 5. Deterministic Randomness (IceFebruary.Random)

* Integrates a predictable, lightweight Xorshift32 algorithm inside Random and a global thread-safe GlobalRandom variant.
* Access to the raw State bitmask allows backing up or restoring the generator seed to replicate the exact same pseudorandom sequence across multi-client or server-authoritative setups.
* Boundaries passed to range methods (BetweenInt / BetweenFloat) are monitored by an internal FixOrder safety layout that automatically flips erroneous inputs (e.g., minimum bound higher than maximum bound) without throwing critical exceptions.

## 6. Cycle and Time Management (IceFebruary.Time)

* Application ticks are governed by the ITime controller interface, which triggers standard frame variations (IFrame) via DoFrame(float frameLength) and fixed-interval iterations (IFixedFrame) via DoFixedFrame().
* Timer: A localized utility designed for managing cooldown periods. It avoids reliance on continuous runtime loops, evaluating duration strictly by comparing numeric time stamps against CurrentTime.

## 7. Non-Alloc Area Scanning & Physics Interfaces (IceFebruary.Physics)

* Translates physical concepts into clear code contracts: IRigidbody2D, ICollider2D, and IHingeJoint2D.
* IShape Geometries: Declares structural primitives (Circle, Rectangle, and a memory-saving singleton Dot) used to map structural bounds.
* AreaScanner & Overlap: IPhysics2D exposes non-allocating environment query options using ContactFilter2D and bitmask-driven LayerMask structures. The data is piped directly into pre-allocated memory buffers to maintain a zero-allocation workflow under heavy workloads.
* PhysicsBalancer: A stabilization component that listens to the IFixedFrame loop to steadily rotate a physical body toward a target rotor. It decouples the core tracking state from the actual formula by calling modular calculators (IPhysicsBalancerCalculator).

## 8. Structural Factories (IceFebruary.Factories)

* IRootConfig: A marker interface used to tag plain structural DTO instances that hold configuration values without embedding any operational code logic.
* ISettableUp Contracts: Formalizes a standard protocol for initializing raw components using structured data models.
* BuilderFactory & Factory: Decorators wrapped around object managers that catch the initialization state of new instances, automatically retrieve their corresponding configuration values (TryGetRootConfig), and bind them safely before exposing them to active processing loops.

## 9. Rendering & State Animation (IceFebruary.Render / Animation)

* Viewport boundaries and state machine behaviors are exposed via ICamera and IAnimator.
* Parameter modifications are tracked via highly optimized identifier hashes (int hash).
* AnimatorField<T> & AnimatorTrigger: Wrappers that encapsulate state variables safely. They handle null checking routines internally: if the main animator object is destroyed during a tick, the fields handle the cleanup automatically and return a predictable default value instead of causing runtime exceptions.

------------------------------

## 🧩 The Compiler Code Generator Pipeline (IceFebruary.Proxy)

The communication layer between this pure logic repository and specialized external development software relies on a series of semantic metadata markers found under the IceFebruary.Proxy namespace. This layer allows a custom code generator tool or an external visual inspector to process the architecture from the outside:

* GeneratorAttribute: The foundational base marker class for all automated mapping commands.
* [InterfaceProxy]: Placed atop interfaces to denote that a dedicated external structural implementation should be auto-generated to mirror and route these behaviors.
* [FieldProxy]: Applied to constructors or parameters to instruct custom external configuration software or visual property editors on how to visually draw and structure these values inside a custom inspector interface.
* [DataObjectProxy]: Tags native structures or data wrappers, signaling the pipeline to securely connect them with binary or text-based external assets.

------------------------------

## 🎮 Production & Examples

This architectural framework is actively used in real-world project layouts. To see how these decoupled subsystems, strategies, and code generation attributes work together under production workloads, check out the complete implementation:

* 🚀 **[https://github.com/AluevLev/FightForStick]** — A complete production-ready project built entirely on top of the IceFebruary architectural framework.

------------------------------

## ⚙️ Technical Requirements

* Language Specification: C# 9.0 or higher.
* Target Runtime: .NET Standard 2.1 / .NET Core 3.1+ or any framework-compliant runtime environment.
* Dependencies: 0% external package overhead. Just pure, clean C#.