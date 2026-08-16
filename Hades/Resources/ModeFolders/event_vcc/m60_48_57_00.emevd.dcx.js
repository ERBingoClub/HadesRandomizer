// ==EMEVD==
// @docs    er-common.emedf.json
// @compress    DCX_KRAK
// @game    Sekiro
// @string    "N:\\GR\\data\\Param\\event\\common_func.emevd\u0000N:\\GR\\data\\Param\\event\\common_macro.emevd\u0000\u0000\u0000\u0000\u0000\u0000"
// @linked    [0,82]
// @version    3.5
// ==/EMEVD==

// コンストラクタ -- constructor
$Event(0, Default, function() {
    $InitializeCommonEvent(0, 90005600, 1048570000, 1048571950, 5, 1048570480);
    $InitializeCommonEvent(0, 90005211, 1048570275, 30000, 20000, 1048572277, 10, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005211, 1048570277, 30000, 20000, 1048572277, 10, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005211, 1048570285, 30000, 20000, 1048572285, 10, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005300, 1048570200, 1048570200, 40526, 0, 0);
    $InitializeCommonEvent(0, 90005300, 1048570250, 1048570250, 1048570900, 0, 0);
    $InitializeCommonEvent(0, 90005300, 1048570251, 1048570251, 1048570910, 0, 0);
    $InitializeCommonEvent(0, 90005300, 1048570252, 1048570252, 1048570920, 0, 0);
    $InitializeCommonEvent(0, 90005300, 1048570253, 1048570253, 1048570930, 0, 0);
    $InitializeEvent(0, 1048572820, 1048570800, 30000, 20000, 1048572800, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005870, 1048570800, 904980607, 24);
    $InitializeCommonEvent(0, 90005860, 1048570800, 0, 1048570800, 0, 1048570700, 0);
    $InitializeCommonEvent(0, 90005605, 1048571500, 15, 0, 0, 0, 15002600, 0, 1048572501, 1048572502, 1048572503, 0, 0, 0, 0);
    $InitializeEvent(0, 1048572300, 1048571300, 1048576300, 1048576301, 1048575300, 1048575301, 1048572300);
    $InitializeEvent(0, 1048572310);
    $InitializeEvent(0, 1048572320, 1048571300);
    $InitializeEvent(0, 1048572350);
    $InitializeEvent(0, 1048572355);
    $InitializeEvent(0, 1048572390);
    $InitializeEvent(0, 1048572340, 1048575310);
    $InitializeEvent(0, 1048572370, 1048571370, 1048571360, 1048570370);
    $InitializeEvent(1, 1048572370, 1048571371, 1048571361, 1048570371);
    $InitializeEvent(2, 1048572370, 1048571372, 1048571362, 1048570372);
    $InitializeEvent(3, 1048572370, 1048571373, 1048571363, 1048570373);
    $InitializeCommonEvent(0, 90005261, 1048570250, 1048572250, 5, 0, -1);
    $InitializeEvent(0, 1048572256);
    $InitializeEvent(0, 1048572260);
    $InitializeEvent(0, 1048572270);
    $InitializeEvent(0, 1048572275, 1048570255);
    $InitializeEvent(0, 1048572580);
    $InitializeEvent(0, 1048572400);
});

// 黒き刃の末裔_死体待機 -- Descendant of the Black Blade_Waiting for corpse
$Event(1048572256, Restart, function() {
    ForceAnimationPlayback(1048570256, 30001, true, false, false);
});

// 黒き刃の末裔_姿隠し暴き -- Descendants of the Black Blade_Hidden Revealed
$Event(1048572260, Restart, function() {
    DisableNetworkSync();
    WaitFor(CharacterHasSpEffect(20000, 416));
    SetSpEffect(20000, 14508);
    WaitFixedTimeSeconds(1);
    RestartEvent();
});

// 黒き刃の末裔_姿隠し暴き_霊体用 -- Descendants of the Black Blade_Hidden Revealing_For Spirits
$Event(1048572270, Restart, function() {
    WaitFor(CharacterHasSpEffect(1048570255, 14507));
    SetSpEffect(1048570254, 14507);
    WaitFixedTimeSeconds(1);
    RestartEvent();
});

// 黒き刃の末裔_ダミーキャラ無敵化 -- Descendants of the Black Blade_Dummy character made invincible
$Event(1048572275, Restart, function(chrEntityId) {
    EnableCharacterInvincibility(chrEntityId);
    DisableLockOnPoint(chrEntityId, 220);
    EndEvent();
});

// 雪街_封牢_ワープイベント -- Snow Town_Confinement_Warp Event
$Event(1048572300, Restart, function(entityId, assetEntityId, assetEntityId2, chrEntityId, chrEntityId2, chrEntityId3) {
    DisableNetworkSync();
    GotoIf(L5, EventFlag(1048572308));
    GotoIf(L6, EventFlag(1048572309));
    DeactivateGparamOverride(0);
    DisableAsset(assetEntityId);
    EnableAsset(assetEntityId2);
    EnableCharacter(chrEntityId);
    DisableCharacterInvincibility(chrEntityId);
    DisableCharacter(chrEntityId2);
    EnableCharacterInvincibility(chrEntityId2);
    ClearSpEffect(10000, 190);
    EnableAssetTreasure(1048571256);
    SetEventFlagID(1048572308, ON);
    SetEventFlagID(1048572309, OFF);
    SetEventFlagID(1048572305, ON);
    SetEventFlagID(1048572308, ON);
    SetEventFlagID(1048572309, OFF);
    WaitFixedTimeSeconds(1);
    RestartEvent();
L5:
    EndIf(EventFlag(1048572309));
    DeactivateGparamOverride(0);
    DisableAsset(assetEntityId);
    EnableAsset(assetEntityId2);
    EnableCharacter(chrEntityId);
    DisableCharacterInvincibility(chrEntityId);
    DisableCharacter(chrEntityId2);
    EnableCharacterInvincibility(chrEntityId2);
    ClearSpEffect(10000, 190);
    EnableAssetTreasure(1048571256);
    Goto(L7);
L6:
    ActivateGparamOverride(0, 0);
    EnableAsset(assetEntityId);
    DisableAsset(assetEntityId2);
    DisableCharacter(chrEntityId);
    EnableCharacterInvincibility(chrEntityId);
    EnableCharacter(chrEntityId2);
    DisableCharacterInvincibility(chrEntityId2);
    SetSpEffect(10000, 190);
    DisableAssetTreasure(1048571256);
    DeleteAssetfollowingSFX(1048571950, true);
    SetSpEffect(10000, 514);
L7:
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(1048572309));
    EndIf(EventFlag(1048570350));
    WaitForEventFlag(ON, TargetEventFlagType.EventFlag, 1048570310);
    WaitFor(
        !HasMultiplayerState(MultiplayerState.MultiplayerPending)
            && HasMultiplayerState(MultiplayerState.Singleplayer)
            && ActionButtonInArea(9527, entityId));
    DisplayGenericDialogAndSetEventFlags(30021, PromptType.YESNO, NumberofOptions.TwoButtons, entityId, 3, 1048572306, 1048572307, 0);
    if (!EventFlag(1048572306)) {
        WaitFixedTimeSeconds(1);
        RestartEvent();
    }
L2:
    RestartIf(
        HasMultiplayerState(MultiplayerState.Multiplayer)
            || HasMultiplayerState(MultiplayerState.MultiplayerPending));
    WaitFixedTimeFrames(1);
    ForceAnimationPlayback(10000, 60450, false, false, false);
    WaitFixedTimeSeconds(1);
    WarpCharacterAndCopyFloorWithFadeout(10000, TargetEntityType.Area, chrEntityId3, -1, 10000, false, true);
    WaitFixedTimeSeconds(1);
    ForceAnimationPlayback(10000, 60451, false, false, true);
    SetEventFlagID(1048572305, ON);
    ActivateGparamOverride(0, 1.5);
    ShootBullet(1048570310, 1048572310, 100, 100930, 0, 90, 0);
    EnableAsset(assetEntityId);
    DisableAsset(assetEntityId2);
    DisableCharacter(chrEntityId);
    DisableCharacter(1248550350);
    DisableCharacter(1248550351);
    DisableCharacter(1248550360);
    DisableCharacter(1248550361);
    EnableCharacterInvincibility(chrEntityId);
    EnableCharacterInvincibility(1248550350);
    EnableCharacterInvincibility(1248550351);
    EnableCharacterInvincibility(1248550360);
    EnableCharacterInvincibility(1248550361);
    EnableCharacter(chrEntityId2);
    DisableCharacterInvincibility(chrEntityId2);
    SetSpEffect(10000, 190);
    DisableAssetTreasure(1048571256);
    DeleteAssetfollowingSFX(1048571950, true);
    SetSpEffect(10000, 514);
    SetEventFlagID(1048572308, OFF);
    SetEventFlagID(1048572309, ON);
    Goto(L1);
L1:
    SetEventFlagID(1048572306, OFF);
    SetEventFlagID(1048572307, OFF);
    WaitFixedTimeSeconds(1);
    RestartEvent();
});

// ガーゴイル像_ヒントテキスト表示 -- Gargoyle statue_hint text display
$Event(1048572310, Restart, function() {
    DisableNetworkSync();
    WaitFor(PlayerIsInOwnWorld() && ActionButtonInArea(9210, 1048571310));
    DisplayGenericDialog(60100, PromptType.OKCANCEL, NumberofOptions.NoButtons, 1048571310, 3);
    WaitFixedTimeSeconds(1);
    SetNetworkconnectedEventFlagID(1048570310, ON);
    RestartEvent();
});

// 雪街_封牢_SFX表示 -- Snow town_confinement_SFX display
$Event(1048572320, Restart, function(entityId) {
    ForceAnimationPlayback(entityId, 0, true, false, false);
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(1048570350));
    ForceAnimationPlayback(entityId, 10, true, false, false);
    WaitForEventFlag(ON, TargetEventFlagType.EventFlag, 1048570310);
    EndIf(EventFlag(1048572309));
    WaitFor(
        HasMultiplayerState(MultiplayerState.Singleplayer)
            && !HasMultiplayerState(MultiplayerState.MultiplayerPending)
            && EventFlag(1048570310));
    WaitFixedTimeFrames(1);
    ForceAnimationPlayback(entityId, 1, true, false, false);
    WaitFor(
        !(HasMultiplayerState(MultiplayerState.Singleplayer)
            && !HasMultiplayerState(MultiplayerState.MultiplayerPending))
            || EventFlag(1048572309));
    WaitFixedTimeFrames(1);
    RestartEvent();
});

// 表世界のエネミー_霊体化 -- Enemy of the surface world_spiritualization
$Event(1048572340, Restart, function(chrEntityId) {
    DisableCharacterCollision(chrEntityId);
    DisableLockOnPoint(chrEntityId, 220);
    EndEvent();
});

// 雪街_霧壁解除_最奥 -- Snow town_fog wall removed_deepest
$Event(1048572350, Restart, function() {
    if (!EventFlag(1048570350)) {
        DeleteAssetfollowingSFX(1048571350, false);
        CreateAssetfollowingSFX(1048571350, 200, 1505);
        WaitFor(
            PlayerIsInOwnWorld()
                && EventFlag(1048570370)
                && EventFlag(1048570371)
                && EventFlag(1048570372)
                && EventFlag(1048570373));
        SetEventFlagID(1048570350, ON);
        WaitFixedTimeSeconds(2.3);
        
        // Unlock the Haligtree Roots Grace
        //SetEventFlagID(71504, ON);
        // Unlock Mohgwyn Dynasty Midpoint
        //SetEventFlagID(71253, ON);
        
        // A seal was broken in town, and new graces were unlocked
        //DisplayGenericDialog(30071, PromptType.OKCANCEL, NumberofOptions.NoButtons, 0, 5);
        
        DisableAsset(1048571350);
        DeleteAssetfollowingSFX(1048571350, true);
        PlaySE(1048571350, SoundType.SFX, 1500);
        SetSpEffect(20000, 8870);
        WaitFixedTimeSeconds(4.5);
        WarpPlayer(60, 48, 57, 0, 1048572301, 0);
        EndEvent();
        EndEvent();
    }
L0:
    DisableAsset(1048571350);
    DeleteAssetfollowingSFX(1048571350, true);
    PlaySE(1048571350, SoundType.SFX, 1500);
    EndEvent();
});

// 雪街_霧壁解除_その他 -- Snow town_Fog wall removal_Others
$Event(1048572355, Restart, function() {
    if (!EventFlag(1048570350)) {
        DeleteAssetfollowingSFX(1048571380, false);
        DeleteAssetfollowingSFX(1048571381, false);
        DeleteAssetfollowingSFX(1048571382, false);
        DeleteAssetfollowingSFX(1048571383, false);
        DeleteAssetfollowingSFX(1048571384, false);
        DeleteAssetfollowingSFX(1048571385, false);
        CreateAssetfollowingSFX(1048571380, 200, 1503);
        CreateAssetfollowingSFX(1048571381, 200, 1503);
        CreateAssetfollowingSFX(1048571382, 200, 1503);
        CreateAssetfollowingSFX(1048571383, 200, 1503);
        CreateAssetfollowingSFX(1048571384, 200, 1503);
        CreateAssetfollowingSFX(1048571385, 200, 1503);
        WaitFor(EventFlag(1048572309));
    }
L0:
    DisableAsset(1048571380);
    DisableAsset(1048571381);
    DisableAsset(1048571382);
    DisableAsset(1048571383);
    DisableAsset(1048571384);
    DisableAsset(1048571385);
    DeleteAssetfollowingSFX(1048571380, false);
    DeleteAssetfollowingSFX(1048571381, false);
    DeleteAssetfollowingSFX(1048571382, false);
    DeleteAssetfollowingSFX(1048571383, false);
    DeleteAssetfollowingSFX(1048571384, false);
    DeleteAssetfollowingSFX(1048571385, false);
    EndEvent();
});

// 雪街_封印解除像_アクションボタン表示_xx -- Snow town_Seal release statue_Action button display_xx
$Event(1048572370, Restart, function(assetEntityId, assetEntityId2, eventFlagId) {
    DeleteAssetfollowingSFX(assetEntityId, true);
    if (!EventFlag(eventFlagId)) {
        WaitForEventFlag(ON, TargetEventFlagType.EventFlag, 1048572309);
        WaitFor(PlayerIsInOwnWorld() && ActionButtonInArea(9528, assetEntityId));
        WaitFixedTimeFrames(1);
        ForceAnimationPlayback(10000, 60550, false, false, false);
        SetEventFlagID(eventFlagId, ON);
        WaitFixedTimeSeconds(1.2);
    }
L0:
    DeleteAssetfollowingSFX(assetEntityId2, true);
    CreateAssetfollowingSFX(assetEntityId2, 200, 806061);
    WaitForEventFlag(ON, TargetEventFlagType.EventFlag, 1048572309);
    CreateAssetfollowingSFX(assetEntityId, 200, 806060);
    EndEvent();
    GotoIf(L0, EventFlag(1048572309));
});

// 雪街_霧壁エラーメッセージ -- Snow town_fog wall error message
$Event(1048572390, Restart, function() {
    DisableNetworkSync();
    EndIf(EventFlag(1048570350));
    WaitFor(ActionButtonInArea(9529, 1048571350) || EventFlag(1048570350));
    EndIf(EventFlag(1048570350));
    DisplayGenericDialog(30023, PromptType.OKCANCEL, NumberofOptions.NoButtons, 1048571350, 3);
    WaitFixedTimeSeconds(1);
    RestartEvent();
});

// 雪街_幻影アセット無効化 -- Snow town_phantom asset invalidation
$Event(1048572400, Restart, function() {
    DisableAsset(1048576305);
});

// 雪街_梯子登録 -- Snow town_ladder registration
$Event(1048572580, Restart, function() {
    RegisterLadder(1048570580, 1048570581, 1048571580);
    RegisterLadder(1048570582, 1048570583, 1048571582);
    RegisterLadder(1048570584, 1048570585, 1048571584);
    RegisterLadder(1048570586, 1048570587, 1048571586);
    RegisterLadder(1048570588, 1048570589, 1048571588);
    RegisterLadder(1048570590, 1048570591, 1048571590);
    RegisterLadder(1048570592, 1048570593, 1048571592);
    RegisterLadder(1048570594, 1048570595, 1048571594);
    RegisterLadder(1048570596, 1048570597, 1048571596);
});

// 死の鳥_特殊待機_領域判定 -- Bird of Death_Special Standby_Area Judgment
$Event(1048572820, Restart, function(chrEntityId, animationId, animationId2, areaEntityId, timeSeconds, value, value2, value3, value4) {
    EndIf(SpecialStandbyEndedFlag(chrEntityId));
    if (value != 0) {
        DisableCharacterGravity(chrEntityId);
        SetCharacterMaphit(chrEntityId, false);
    }
    DisableCharacterAI(chrEntityId);
    ForceAnimationPlayback(chrEntityId, animationId, true, false, false);
    chrSp = (CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
        || CharacterType(10000, TargetType.Alive)
        || CharacterType(10000, TargetType.GrayPhantom)
        || CharacterType(10000, TargetType.WhitePhantom);
    areaChrSp &= InArea(10000, areaEntityId)
        && CharacterBackreadStatus(chrEntityId)
        && (CharacterHasSpEffect(chrEntityId, 5080) || CharacterHasSpEffect(chrEntityId, 5450));
    if (!(value2 == 0 && value3 == 0 && value4 == 0)) {
        if (value2 != 0) {
            chr |= CharacterAIState(chrEntityId, AIStateType.Combat);
        }
        if (value3 != 0) {
            chr |= CharacterAIState(chrEntityId, AIStateType.ActiveAlert);
        }
        if (value4 != 0) {
            chr |= CharacterAIState(chrEntityId, AIStateType.PassiveAlert);
        }
        areaChrSp &= chr;
    }
L9:
    sp = CharacterHasSpEffect(chrEntityId, 481)
        && !CharacterHasSpEffect(chrEntityId, 90100)
        && !CharacterHasSpEffect(chrEntityId, 90110)
        && !CharacterHasSpEffect(chrEntityId, 90160);
    sp2 = CharacterHasSpEffect(chrEntityId, 482)
        && !CharacterHasSpEffect(chrEntityId, 90100)
        && !CharacterHasSpEffect(chrEntityId, 90120)
        && !CharacterHasSpEffect(chrEntityId, 90160)
        && !CharacterHasSpEffect(chrEntityId, 90162);
    sp3 = CharacterHasSpEffect(chrEntityId, 483)
        && !CharacterHasSpEffect(chrEntityId, 90100)
        && !CharacterHasSpEffect(chrEntityId, 90140)
        && !CharacterHasSpEffect(chrEntityId, 90160)
        && !CharacterHasSpEffect(chrEntityId, 90161);
    sp4 = CharacterHasSpEffect(chrEntityId, 484)
        && !CharacterHasSpEffect(chrEntityId, 90100)
        && !CharacterHasSpEffect(chrEntityId, 90130)
        && !CharacterHasSpEffect(chrEntityId, 90161)
        && !CharacterHasSpEffect(chrEntityId, 90162);
    sp5 = CharacterHasSpEffect(chrEntityId, 487)
        && !CharacterHasSpEffect(chrEntityId, 90100)
        && !CharacterHasSpEffect(chrEntityId, 90150)
        && !CharacterHasSpEffect(chrEntityId, 90160);
    areaChrSp &= chrSp;
    WaitFor(
        areaChrSp
            || HasDamageType(chrEntityId, 0, DamageType.Unspecified)
            || CharacterHasStateInfo(chrEntityId, 436)
            || CharacterHasStateInfo(chrEntityId, 2)
            || CharacterHasStateInfo(chrEntityId, 5)
            || CharacterHasStateInfo(chrEntityId, 6)
            || CharacterHasStateInfo(chrEntityId, 260)
            || sp
            || sp2
            || sp3
            || sp4
            || sp5);
    WaitFixedTimeSeconds(0.1);
    if (!(!CharacterHasSpEffect(chrEntityId, 5080) && !CharacterHasSpEffect(chrEntityId, 5450))) {
        SetNetworkconnectedThisEventSlot(ON);
        SetSpecialStandbyEndedFlag(chrEntityId, ON);
        WaitFixedTimeSeconds(timeSeconds);
        if (value != 0) {
            EnableCharacterGravity(chrEntityId);
            SetCharacterMaphit(chrEntityId, true);
        }
        EnableCharacterAI(chrEntityId);
        ForceAnimationPlayback(chrEntityId, animationId2, true, false, false);
        EndEvent();
    }
L0:
    if (value != 0) {
        EnableCharacterGravity(chrEntityId);
        SetCharacterMaphit(chrEntityId, true);
    }
    EndEvent();
});
