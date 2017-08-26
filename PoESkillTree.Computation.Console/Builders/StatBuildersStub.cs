﻿using PoESkillTree.Computation.Parsing.Builders.Actions;
using PoESkillTree.Computation.Parsing.Builders.Conditions;
using PoESkillTree.Computation.Parsing.Builders.Stats;

namespace PoESkillTree.Computation.Console.Builders
{
    public abstract class StatBuildersStubBase
    {
        protected IConditionBuilders ConditionBuilders { get; }

        protected StatBuildersStubBase(IConditionBuilders conditionBuilders)
        {
            ConditionBuilders = conditionBuilders;
        }

        protected IStatBuilder Create(string stringRepresentation)
        {
            return new StatBuilderStub(stringRepresentation, ConditionBuilders);
        }
    }

    public class StatBuildersStub : StatBuildersStubBase, IStatBuilders
    {
        public StatBuildersStub(IConditionBuilders conditionBuilders) : base(conditionBuilders)
        {
        }

        public IStatBuilder Armour => Create("Armour");

        public IEvasionStatBuilder Evasion =>
            new EvasionStatBuilderStub("Evasion", ConditionBuilders);

        public IStatBuilder Accuracy => Create("Accuracy");

        public IStatBuilder MovementSpeed => Create("Movement Speed");
        public IStatBuilder AnimationSpeed => Create("Animation Speed");

        public IStatBuilder Range => Create("Range");

        public IStatBuilder TrapTriggerAoE => Create("Trap trigger AoE");
        public IStatBuilder MineDetonationAoE => Create("Mine detonation AoE");

        public IStatBuilder ItemQuantity => Create("Item Quantity");
        public IStatBuilder ItemRarity => Create("Item Rarity");

        public IStatBuilder PrimordialJewelsSocketed => Create("Socketed Primoridal jewels");
        public IStatBuilder GrandSpectrumJewelsSocketed => Create("Socketed Grand Spectrum jewels");

        public IStatBuilder RampageStacks => Create("Rampage Stacks");

        public IAttributeStatBuilders Attribute => new AttributeStatBuildersStub(ConditionBuilders);
        public IPoolStatBuilders Pool => new PoolStatBuildersStub(ConditionBuilders);
        public IDodgeStatBuilders Dodge => new DodgeStatBuildersStub(ConditionBuilders);
        public IFlaskStatBuilders Flask => new FlaskStatBuildersStub(ConditionBuilders);
        public IProjectileStatBuilders Projectile => new ProjectileStatBuildersStub(ConditionBuilders);
        public IFlagStatBuilders Flag => new FlagStatBuildersStub(ConditionBuilders);
        public IGemStatBuilders Gem => new GemStatBuildersStub(ConditionBuilders);

        public IStatBuilder ApplyOnce(params IStatBuilder[] stats) =>
            Create($"ApplyOnce({string.Join<IStatBuilder>(", ", stats)})");

        public IStatBuilder Unique(string name = "$0") => Create(name);
    }


    public class AttributeStatBuildersStub : StatBuildersStubBase, IAttributeStatBuilders
    {
        public AttributeStatBuildersStub(IConditionBuilders conditionBuilders) : base(conditionBuilders)
        {
        }

        public IStatBuilder Strength => Create("Strength");
        public IStatBuilder Dexterity => Create("Dexterity");
        public IStatBuilder Intelligence => Create("Intelligence");
        public IStatBuilder StrengthDamageBonus => Create("Strength damage bonus");
        public IStatBuilder DexterityEvasionBonus => Create("Dexterity evasion bonus");
    }


    public class DodgeStatBuildersStub : StatBuildersStubBase, IDodgeStatBuilders
    {
        public DodgeStatBuildersStub(IConditionBuilders conditionBuilders) : base(conditionBuilders)
        {
        }

        public IStatBuilder AttackChance => Create("Chance to dodge attacks");
        public IStatBuilder SpellChance => Create("Chance to dodge spells");
    }


    public class FlaskStatBuildersStub : StatBuildersStubBase, IFlaskStatBuilders
    {
        public FlaskStatBuildersStub(IConditionBuilders conditionBuilders) : base(conditionBuilders)
        {
        }

        public IStatBuilder Effect => Create("Flask effect");
        public IStatBuilder Duration => Create("Flask effect duration");
        public IStatBuilder LifeRecovery => Create("Flask life recovery");
        public IStatBuilder ManaRecovery => Create("Flask mana recovery");
        public IStatBuilder RecoverySpeed => Create("Flask recovery speed");
        public IStatBuilder ChargesUsed => Create("Flask charges used");
        public IStatBuilder ChargesGained => Create("Flask charges gained");

        public IConditionBuilder IsAnyActive =>
            new ConditionBuilderStub("Any flask is active");
    }


    public class GemStatBuildersStub : StatBuildersStubBase, IGemStatBuilders
    {
        public GemStatBuildersStub(IConditionBuilders conditionBuilders) : base(conditionBuilders)
        {
        }

        public IStatBuilder IncreaseLevel(bool onlySupportGems = false) => 
            Create(onlySupportGems ? "Level of socketed support gems" : "Level of socketed gems");
    }


    public class ProjectileStatBuildersStub : StatBuildersStubBase, IProjectileStatBuilders
    {
        public ProjectileStatBuildersStub(IConditionBuilders conditionBuilders) : base(conditionBuilders)
        {
        }

        public IStatBuilder Speed => Create("Projectile speed");
        public IStatBuilder Count => Create("Projectile count");

        public IStatBuilder PierceCount => Create("Projectile pierce count");

        public ISelfToAnyActionBuilder Pierce =>
            new SelfToAnyActionBuilderStub("Projectile pierce", ConditionBuilders);

        public IStatBuilder ChainCount => Create("Projectile chain count");
        public IStatBuilder TravelDistance => Create("Projectile travel distance");
    }
}