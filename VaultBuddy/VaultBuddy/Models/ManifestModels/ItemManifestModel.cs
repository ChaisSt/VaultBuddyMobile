using Newtonsoft.Json;
using System.Collections.Generic;
//670 lines
namespace VaultBuddy.Models
{
    public partial class ItemManifestModel
    {
        [JsonProperty("displayProperties")]
        public DisplayProperties DisplayProperties { get; set; }

        [JsonProperty("tooltipNotifications")]
        public object[] TooltipNotifications { get; set; }

        [JsonProperty("collectibleHash")]
        public long CollectibleHash { get; set; }

        [JsonProperty("iconWatermark")]
        public string IconWatermark { get; set; }

        [JsonProperty("iconWatermarkShelved")]
        public string IconWatermarkShelved { get; set; }

        [JsonProperty("backgroundColor")]
        public BackgroundColor BackgroundColor { get; set; }

        [JsonProperty("screenshot")]
        public string Screenshot { get; set; }

        [JsonProperty("itemTypeDisplayName")]
        public string ItemTypeDisplayName { get; set; }

        [JsonProperty("uiItemDisplayStyle")]
        public string UiItemDisplayStyle { get; set; }

        [JsonProperty("itemTypeAndTierDisplayName")]
        public string ItemTypeAndTierDisplayName { get; set; }

        [JsonProperty("displaySource")]
        public string DisplaySource { get; set; }

        [JsonProperty("action")]
        public Action Action { get; set; }

        [JsonProperty("inventory")]
        public Inventory Inventory { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("equippingBlock")]
        public EquippingBlock EquippingBlock { get; set; }

        [JsonProperty("translationBlock")]
        public TranslationBlock TranslationBlock { get; set; }

        [JsonProperty("preview")]
        public Preview Preview { get; set; }

        [JsonProperty("quality")]
        public Quality Quality { get; set; }

        [JsonProperty("acquireRewardSiteHash")]
        public long AcquireRewardSiteHash { get; set; }

        [JsonProperty("acquireUnlockHash")]
        public long AcquireUnlockHash { get; set; }

        [JsonProperty("sockets")]
        public Sockets Sockets { get; set; }

        [JsonProperty("talentGrid")]
        public TalentGrid TalentGrid { get; set; }

        [JsonProperty("investmentStats")]
        public InvestmentStat[] InvestmentStats { get; set; }

        [JsonProperty("perks")]
        public object[] Perks { get; set; }

        [JsonProperty("loreHash")]
        public long LoreHash { get; set; }

        [JsonProperty("summaryItemHash")]
        public long SummaryItemHash { get; set; }

        [JsonProperty("allowActions")]
        public bool AllowActions { get; set; }

        [JsonProperty("doesPostmasterPullHaveSideEffects")]
        public bool DoesPostmasterPullHaveSideEffects { get; set; }

        [JsonProperty("nonTransferrable")]
        public bool NonTransferrable { get; set; }

        [JsonProperty("itemCategoryHashes")]
        public long[] ItemCategoryHashes { get; set; }

        [JsonProperty("specialItemType")]
        public long SpecialItemType { get; set; }

        [JsonProperty("itemType")]
        public long ItemType { get; set; }

        [JsonProperty("itemSubType")]
        public long ItemSubType { get; set; }

        [JsonProperty("classType")]
        public long ClassType { get; set; }

        [JsonProperty("breakerType")]
        public long BreakerType { get; set; }

        [JsonProperty("equippable")]
        public bool Equippable { get; set; }

        [JsonProperty("damageTypeHashes")]
        public long[] DamageTypeHashes { get; set; }

        [JsonProperty("damageTypes")]
        public long[] DamageTypes { get; set; }

        [JsonProperty("defaultDamageType")]
        public long DefaultDamageType { get; set; }

        [JsonProperty("defaultDamageTypeHash")]
        public long DefaultDamageTypeHash { get; set; }

        [JsonProperty("isWrapper")]
        public bool IsWrapper { get; set; }

        [JsonProperty("traitIds")]
        public string[] TraitIds { get; set; }

        [JsonProperty("hash")]
        public long Hash { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("redacted")]
        public bool Redacted { get; set; }

        [JsonProperty("blacklisted")]
        public bool Blacklisted { get; set; }

        [JsonProperty("secondaryIcon")]
        public string SecondaryIcon { get; set; }

        [JsonProperty("tooltipStyle")]
        public string TooltipStyle { get; set; }

        [JsonProperty("objectives")]
        public Objectives Objectives { get; set; }
    }

    public partial class Action
    {
        [JsonProperty("verbName")]
        public string VerbName { get; set; }

        [JsonProperty("verbDescription")]
        public string VerbDescription { get; set; }

        [JsonProperty("isPositive")]
        public bool IsPositive { get; set; }

        [JsonProperty("requiredCooldownSeconds")]
        public long RequiredCooldownSeconds { get; set; }

        [JsonProperty("requiredItems")]
        public object[] RequiredItems { get; set; }

        [JsonProperty("progressionRewards")]
        public object[] ProgressionRewards { get; set; }

        [JsonProperty("rewardSheetHash")]
        public long RewardSheetHash { get; set; }

        [JsonProperty("rewardItemHash")]
        public long RewardItemHash { get; set; }

        [JsonProperty("rewardSiteHash")]
        public long RewardSiteHash { get; set; }

        [JsonProperty("requiredCooldownHash")]
        public long RequiredCooldownHash { get; set; }

        [JsonProperty("deleteOnAction")]
        public bool DeleteOnAction { get; set; }

        [JsonProperty("consumeEntireStack")]
        public bool ConsumeEntireStack { get; set; }

        [JsonProperty("useOnAcquire")]
        public bool UseOnAcquire { get; set; }

        [JsonProperty("actionTypeLabel")]
        public string ActionTypeLabel { get; set; }
    }

    public partial class BackgroundColor
    {
        [JsonProperty("colorHash")]
        public long ColorHash { get; set; }

        [JsonProperty("red")]
        public long Red { get; set; }

        [JsonProperty("green")]
        public long Green { get; set; }

        [JsonProperty("blue")]
        public long Blue { get; set; }

        [JsonProperty("alpha")]
        public long Alpha { get; set; }
    }

    public partial class DisplayProperties
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("hasIcon")]
        public bool HasIcon { get; set; }

        [JsonProperty("highResIcon")]
        public string HighResIcon { get; set; }
    }

    public partial class EquippingBlock
    {
        [JsonProperty("uniqueLabelHash")]
        public long UniqueLabelHash { get; set; }

        [JsonProperty("equipmentSlotTypeHash")]
        public long EquipmentSlotTypeHash { get; set; }

        [JsonProperty("attributes")]
        public long Attributes { get; set; }

        [JsonProperty("equippingSoundHash")]
        public long EquippingSoundHash { get; set; }

        [JsonProperty("hornSoundHash")]
        public long HornSoundHash { get; set; }

        [JsonProperty("ammoType")]
        public long AmmoType { get; set; }

        [JsonProperty("displayStrings")]
        public object[] DisplayStrings { get; set; }
    }

    public partial class Inventory
    {
        [JsonProperty("maxStackSize")]
        public long MaxStackSize { get; set; }

        [JsonProperty("bucketTypeHash")]
        public long BucketTypeHash { get; set; }

        [JsonProperty("recoveryBucketTypeHash")]
        public long RecoveryBucketTypeHash { get; set; }

        [JsonProperty("tierTypeHash")]
        public long TierTypeHash { get; set; }

        [JsonProperty("isInstanceItem")]
        public bool IsInstanceItem { get; set; }

        [JsonProperty("nonTransferrableOriginal")]
        public bool NonTransferrableOriginal { get; set; }

        [JsonProperty("tierTypeName")]
        public string TierTypeName { get; set; }

        [JsonProperty("tierType")]
        public long TierType { get; set; }

        [JsonProperty("expirationTooltip")]
        public string ExpirationTooltip { get; set; }

        [JsonProperty("expiredInActivityMessage")]
        public string ExpiredInActivityMessage { get; set; }

        [JsonProperty("expiredInOrbitMessage")]
        public string ExpiredInOrbitMessage { get; set; }

        [JsonProperty("suppressExpirationWhenObjectivesComplete")]
        public bool SuppressExpirationWhenObjectivesComplete { get; set; }

        [JsonProperty("stackUniqueLabel")]
        public string StackUniqueLabel { get; set; }
    }

    public partial class Preview
    {
        [JsonProperty("screenStyle")]
        public string ScreenStyle { get; set; }

        [JsonProperty("previewVendorHash")]
        public long PreviewVendorHash { get; set; }

        [JsonProperty("previewActionString")]
        public string PreviewActionString { get; set; }
    }

    public partial class Sockets
    {
        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("socketEntries")]
        public SocketEntry[] SocketEntries { get; set; }

        [JsonProperty("intrinsicSockets")]
        public object[] IntrinsicSockets { get; set; }

        [JsonProperty("socketCategories")]
        public SocketCategory[] SocketCategories { get; set; }
    }

    public partial class SocketCategory
    {
        [JsonProperty("socketCategoryHash")]
        public long SocketCategoryHash { get; set; }

        [JsonProperty("socketIndexes")]
        public long[] SocketIndexes { get; set; }
    }

    public partial class SocketEntry
    {
        [JsonProperty("socketTypeHash")]
        public long SocketTypeHash { get; set; }

        [JsonProperty("singleInitialItemHash")]
        public long SingleInitialItemHash { get; set; }

        [JsonProperty("reusablePlugItems")]
        public ReusablePlugItem[] ReusablePlugItems { get; set; }

        [JsonProperty("preventInitializationOnVendorPurchase")]
        public bool PreventInitializationOnVendorPurchase { get; set; }

        [JsonProperty("preventInitializationWhenVersioning")]
        public bool PreventInitializationWhenVersioning { get; set; }

        [JsonProperty("hidePerksInItemTooltip")]
        public bool HidePerksInItemTooltip { get; set; }

        [JsonProperty("plugSources")]
        public long PlugSources { get; set; }

        [JsonProperty("reusablePlugSetHash", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReusablePlugSetHash { get; set; }

        [JsonProperty("overridesUiAppearance")]
        public bool OverridesUiAppearance { get; set; }

        [JsonProperty("defaultVisible")]
        public bool DefaultVisible { get; set; }
    }

    public partial class ReusablePlugItem
    {
        [JsonProperty("plugItemHash")]
        public long PlugItemHash { get; set; }
    }

    public partial class ItemModelStats
    {
        [JsonProperty("disablePrimaryStatDisplay")]
        public bool DisablePrimaryStatDisplay { get; set; }

        [JsonProperty("statGroupHash")]
        public long StatGroupHash { get; set; }

        [JsonProperty("stats")]
        public StatsStats Stats { get; set; }

        [JsonProperty("hasDisplayableStats")]
        public bool HasDisplayableStats { get; set; }

        [JsonProperty("primaryBaseStatHash")]
        public long PrimaryBaseStatHash { get; set; }
    }

    public partial class TalentGrid
    {
        [JsonProperty("talentGridHash")]
        public long TalentGridHash { get; set; }

        [JsonProperty("itemDetailString")]
        public string ItemDetailString { get; set; }

        [JsonProperty("hudDamageType")]
        public long HudDamageType { get; set; }

        [JsonProperty("buildName")]
        public string BuildName { get; set; }

        [JsonProperty("hudIcon")]
        public string HudIcon { get; set; }
    }

    public partial class TranslationBlock
    {
        [JsonProperty("weaponPatternHash")]
        public long WeaponPatternHash { get; set; }

        [JsonProperty("defaultDyes")]
        public DefaultDye[] DefaultDyes { get; set; }

        [JsonProperty("lockedDyes")]
        public object[] LockedDyes { get; set; }

        [JsonProperty("customDyes")]
        public object[] CustomDyes { get; set; }

        [JsonProperty("arrangements")]
        public Arrangement[] Arrangements { get; set; }

        [JsonProperty("hasGeometry")]
        public bool HasGeometry { get; set; }
    }

    public partial class Arrangement
    {
        [JsonProperty("classHash")]
        public long ClassHash { get; set; }

        [JsonProperty("artArrangementHash")]
        public long ArtArrangementHash { get; set; }
    }

    public partial class DefaultDye
    {
        [JsonProperty("channelHash")]
        public long ChannelHash { get; set; }

        [JsonProperty("dyeHash")]
        public long DyeHash { get; set; }
    }

    public partial class InvestmentStat
    {
        [JsonProperty("statTypeHash")]
        public long StatTypeHash { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("isConditionallyActive")]
        public bool IsConditionallyActive { get; set; }
    }

    public partial class StatsStats
    {
        [JsonProperty("1501155019")]
        public The1501155019 The1501155019 { get; set; }
    }

    public partial class The1501155019
    {
        [JsonProperty("statHash")]
        public long StatHash { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("minimum")]
        public long Minimum { get; set; }

        [JsonProperty("maximum")]
        public long Maximum { get; set; }
    }

    public partial class Objectives
    {
        [JsonProperty("objectiveHashes")]
        public long[] ObjectiveHashes { get; set; }

        [JsonProperty("displayActivityHashes")]
        public long[] DisplayActivityHashes { get; set; }

        [JsonProperty("requireFullObjectiveCompletion")]
        public bool RequireFullObjectiveCompletion { get; set; }

        [JsonProperty("questlineItemHash")]
        public long QuestlineItemHash { get; set; }

        [JsonProperty("narrative")]
        public string Narrative { get; set; }

        [JsonProperty("objectiveVerbName")]
        public string ObjectiveVerbName { get; set; }

        [JsonProperty("questTypeIdentifier")]
        public string QuestTypeIdentifier { get; set; }

        [JsonProperty("questTypeHash")]
        public long QuestTypeHash { get; set; }

        [JsonProperty("completionRewardSiteHash")]
        public long CompletionRewardSiteHash { get; set; }

        [JsonProperty("nextQuestStepRewardSiteHash")]
        public long NextQuestStepRewardSiteHash { get; set; }

        [JsonProperty("timestampUnlockValueHash")]
        public long TimestampUnlockValueHash { get; set; }

        [JsonProperty("isGlobalObjectiveItem")]
        public bool IsGlobalObjectiveItem { get; set; }

        [JsonProperty("useOnObjectiveCompletion")]
        public bool UseOnObjectiveCompletion { get; set; }

        [JsonProperty("inhibitCompletionUnlockValueHash")]
        public long InhibitCompletionUnlockValueHash { get; set; }

        [JsonProperty("perObjectiveDisplayProperties")]
        public PerObjectiveDisplayProperty[] PerObjectiveDisplayProperties { get; set; }

        [JsonProperty("displayAsStatTracker")]
        public bool DisplayAsStatTracker { get; set; }
    }

    public partial class PerObjectiveDisplayProperty
    {
        [JsonProperty("displayOnItemPreviewScreen")]
        public bool DisplayOnItemPreviewScreen { get; set; }
    }

    public partial class EquipmentModelStats
    {
        [JsonProperty("disablePrimaryStatDisplay")]
        public bool DisablePrimaryStatDisplay { get; set; }

        [JsonProperty("statGroupHash")]
        public long StatGroupHash { get; set; }

        [JsonProperty("stats")]
        public StatsStats Stats { get; set; }

        [JsonProperty("hasDisplayableStats")]
        public bool HasDisplayableStats { get; set; }

        [JsonProperty("primaryBaseStatHash")]
        public long PrimaryBaseStatHash { get; set; }
    }

    public partial class EquippingBlock
    {
        [JsonProperty("uniqueLabel")]
        public string UniqueLabel { get; set; }
    }

    public partial class Quality
    {
        [JsonProperty("itemLevels")]
        public object[] ItemLevels { get; set; }

        [JsonProperty("qualityLevel")]
        public long QualityLevel { get; set; }

        [JsonProperty("infusionCategoryName")]
        public string InfusionCategoryName { get; set; }

        [JsonProperty("infusionCategoryHash")]
        public long InfusionCategoryHash { get; set; }

        [JsonProperty("infusionCategoryHashes")]
        public long[] InfusionCategoryHashes { get; set; }

        [JsonProperty("progressionLevelRequirementHash")]
        public long ProgressionLevelRequirementHash { get; set; }

        [JsonProperty("currentVersion")]
        public long CurrentVersion { get; set; }

        [JsonProperty("versions")]
        public Version[] Versions { get; set; }

        [JsonProperty("displayVersionWatermarkIcons")]
        public string[] DisplayVersionWatermarkIcons { get; set; }
    }

    public partial class Version
    {
        [JsonProperty("powerCapHash")]
        public long PowerCapHash { get; set; }
    }

    public partial class SocketEntry
    {
        [JsonProperty("randomizedPlugSetHash", NullValueHandling = NullValueHandling.Ignore)]
        public long? RandomizedPlugSetHash { get; set; }
    }

    public partial class IntrinsicSocket
    {
        [JsonProperty("plugItemHash")]
        public long PlugItemHash { get; set; }

        [JsonProperty("socketTypeHash")]
        public long SocketTypeHash { get; set; }

        [JsonProperty("defaultVisible")]
        public bool DefaultVisible { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("disablePrimaryStatDisplay")]
        public bool DisablePrimaryStatDisplay { get; set; }

        [JsonProperty("statGroupHash")]
        public long StatGroupHash { get; set; }

        [JsonProperty("stats")]
        public Dictionary<string, Stat> StatsStats { get; set; }

        [JsonProperty("hasDisplayableStats")]
        public bool HasDisplayableStats { get; set; }

        [JsonProperty("primaryBaseStatHash")]
        public long PrimaryBaseStatHash { get; set; }
    }

    public partial class Stat
    {
        [JsonProperty("statHash")]
        public long StatHash { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("minimum")]
        public long Minimum { get; set; }

        [JsonProperty("maximum")]
        public long Maximum { get; set; }

        [JsonProperty("displayMaximum")]
        public long DisplayMaximum { get; set; }
    }

    public partial class Perk
    {
        [JsonProperty("requirementDisplayString")]
        public string RequirementDisplayString { get; set; }

        [JsonProperty("perkHash")]
        public long PerkHash { get; set; }

        [JsonProperty("perkVisibility")]
        public long PerkVisibility { get; set; }
    }
}
