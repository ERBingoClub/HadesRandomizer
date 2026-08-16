// ==EMEVD==
// @docs    er-common.emedf.json
// @compress    DCX_KRAK
// @game    Sekiro
// @string    "N:\\GR\\data\\Param\\event\\common_func.emevd\u0000N:\\GR\\data\\Param\\event\\m60.emevd\u0000N:\\GR\\data\\Param\\event\\common_macro.emevd\u0000\u0000\u0000\u0000\u0000"
// @linked    [0,82,148]
// @version    3.5
// ==/EMEVD==

// コンストラクタ -- constructor
$Event(0, Default, function() {
    RegisterBonfire(1035444042, 1035441951, 0, 0, 0, 5);
    $InitializeEvent(0, 1035442650, 710680, 1680, 9124, 69240);
    $InitializeEvent(0, 1035443700, 1053440700, 1035441701);
    $InitializeEvent(0, 1035443701, 1053440700);
    $InitializeCommonEvent(0, 90005704, 1053440700, 3181, 3180, 1035449201, 3);
    $InitializeCommonEvent(0, 90005703, 1053440700, 3181, 3182, 1035449201, 3181, 3180, 3184, -1);
    $InitializeCommonEvent(0, 90005702, 1053440700, 3183, 3180, 3184);
    $InitializeCommonEvent(0, 90005740, 1035442705, 1035442706, 1035442707, 1053440700, 700, 1035441700, 700, 0.2, 90201, -1, -1, 1.1);
    $InitializeCommonEvent(0, 90005741, 1035442708, 1035442709, 1035442707, 1053440700, 90203, 0, -1, -1, 0.5);
});

// プリコンストラクタ -- preconstructor
$Event(50, Default, function() {
    SetCharacterBackreadState(1053440700, true);
    $InitializeCommonEvent(0, 90005261, 1035440200, 1035442210, 10, 0, 0);
    $InitializeCommonEvent(0, 90005261, 1035440201, 1035442210, 10, 0, 0);
    $InitializeCommonEvent(0, 90005261, 1035440202, 1035442210, 10, 0, 0);
    $InitializeCommonEvent(0, 90005261, 1035440203, 1035442210, 10, 0, 0);
    $InitializeCommonEvent(0, 90005261, 1035440204, 1035442210, 10, 0, 0);
    $InitializeCommonEvent(0, 90005261, 1035440210, 1035442210, 10, 0, 0);
    $InitializeCommonEvent(0, 90005211, 1035440220, 30000, 20000, 1035442220, 10, 0, 0, 0, 0, 0);
});

// チュートリアルメッセージ_マルチプレイ侵入 -- Tutorial message_Multiplayer invasion
$Event(1035442650, Restart, function(eventFlagId, tutorialParamId, itemId, eventFlagId2) {
    DisableNetworkSync();
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(eventFlagId));
    WaitFor(
        PlayerIsInOwnWorld()
            && EventFlag(eventFlagId)
            && !(HasMultiplayerState(MultiplayerState.Multiplayer)
                || HasMultiplayerState(MultiplayerState.MultiplayerPending))
            && !CharacterHasSpEffect(10000, 9640));
    ShowTutorialPopup(tutorialParamId, true, true);
    EndIf(EventFlag(eventFlagId2));
    DirectlyGivePlayerItem(ItemType.Goods, itemId, eventFlagId, 1);
    SetEventFlagID(eventFlagId2, ON);
});

// NPC301_戦場医師_NPC初期化イベント_バラの教会 -- NPC301_Battlefield Doctor_NPC Initialization Event_Rose Church
$Event(1035443700, Restart, function(chrEntityId, assetEntityId) {
    WaitFixedTimeFrames(1);
    DisableNetworkSync();
    if (PlayerIsInOwnWorld()) {
        if (EventFlag(3180)) {
            SetEventFlagID(31009205, OFF);
        }
    }
L10:
    if (!EventFlag(3188)) {
        if (!EventFlag(3189)) {
            if (!EventFlag(3190)) {
                DisableCharacter(chrEntityId);
                SetCharacterBackreadState(chrEntityId, true);
                DisableAsset(assetEntityId);
                WaitFor(EventFlag(3188) || EventFlag(3189) || EventFlag(3190));
                RestartEvent();
            }
        }
    }
L5:
    EnableAsset(assetEntityId);
    GotoIf(L1, EventFlag(3180));
    GotoIf(L2, EventFlag(3181));
    GotoIf(L3, EventFlag(3182));
    GotoIf(L4, EventFlag(3183));
L1:
    SetCharacterBackreadState(chrEntityId, false);
    EnableCharacter(chrEntityId);
    SetCharacterTeamType(chrEntityId, TeamType.FriendlyNPC);
    ForceAnimationPlayback(chrEntityId, 90100, false, false, false);
    GotoIf(L20, mainGroupAbuse);
L2:
    SetCharacterBackreadState(chrEntityId, false);
    EnableCharacter(chrEntityId);
    SetCharacterTeamType(chrEntityId, TeamType.HostileNPC);
    Goto(L20);
L3:
    SetCharacterBackreadState(chrEntityId, false);
    EnableCharacter(chrEntityId);
    SetCharacterTeamType(chrEntityId, TeamType.HostileNPC);
    Goto(L20);
L4:
    ForceCharacterTreasure(chrEntityId);
    DisableCharacter(chrEntityId);
    SetCharacterBackreadState(chrEntityId, true);
    DisableAsset(assetEntityId);
    Goto(L20);
L20:
    WaitFor(!(EventFlag(3188) || EventFlag(3189) || EventFlag(3190)));
    RestartEvent();
});

// NPC301_戦場医師_バラの教会_敵対時アニメ再生 -- NPC301_Battlefield Doctor_Rose Church_Animation playback when hostile
$Event(1035443701, Restart, function(chrEntityId) {
    EndIf(EventFlag(3181));
    EndIf(EventFlag(3183));
    WaitFor(CharacterHasSpEffect(chrEntityId, 90) || EventFlag(3181));
    EndIf(CharacterHasSpEffect(chrEntityId, 90));
    ForceAnimationPlayback(chrEntityId, 90205, false, false, false);
    EndEvent();
});


