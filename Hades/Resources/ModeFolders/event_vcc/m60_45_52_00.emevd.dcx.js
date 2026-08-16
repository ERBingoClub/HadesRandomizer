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
    RegisterBonfire(76314, 1045521950, 0, 0, 0, 5);
    $InitializeEvent(0, 1045522500);
    $InitializeCommonEvent(0, 90005870, 1045520800, 903250600, 12);
    $InitializeCommonEvent(0, 90005860, 1045520800, 0, 1045520800, 0, 30315, 0);
    $InitializeCommonEvent(0, 90005872, 1045520800, 12, 0);
    $InitializeCommonEvent(0, 9005811, 1045520800, 1045521800, 5, 0);
    $InitializeCommonEvent(0, 90005251, 1045520201, 70, 0, 3006);
    $InitializeEvent(0, 1045522200);
    $InitializeCommonEvent(0, 90005300, 1045520200, 1045520200, 30360, 0, 0);
    $InitializeCommonEvent(0, 90005300, 1045520202, 1045520202, 30365, 0, 0);
    $InitializeCommonEvent(0, 90005251, 1045520300, 100, 0, 0);
    $InitializeCommonEvent(0, 90005251, 1045520301, 100, 0, 0);
    $InitializeCommonEvent(0, 90005251, 1045520302, 100, 0, 0);
    $InitializeCommonEvent(0, 90005251, 1045520303, 100, 0, 0);
    $InitializeCommonEvent(0, 90005251, 1045520304, 100, 0, 0);
    $InitializeCommonEvent(0, 90005201, 1045520400, 30000, 20000, 33, 2, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005560, 1045520600, 1045521600, 0);
    $InitializeCommonEvent(0, 90005683, 62315, 1045521300, 205, 78394, 78394);
    $InitializeCommonEvent(0, 900005610, 1045521685, 100, 800, 1045528600);
    $InitializeCommonEvent(0, 900005610, 1045521680, 100, 800, 0);
    $InitializeCommonEvent(0, 90005780, 1045520800, 1045522160, 1045522161, 1045520710, SummonSignType.NPCWhiteSign, 1045522720, 1042559208, false, 0);
    $InitializeCommonEvent(0, 90005781, 1045520800, 1045522160, 1045522161, 1045520710);
    $InitializeCommonEvent(0, 90005783, 1045520800, 1045522160, 1045522161, 1045520710, 1045522722, 1045522721, 0);
    $InitializeCommonEvent(0, 90005780, 1045520800, 1045522170, 1045522171, 1045520730, SummonSignType.NPCWhiteSign, 1045522731, 1045529250, false, 0);
    $InitializeCommonEvent(0, 90005781, 1045520800, 1045522170, 1045522171, 1045520730);
    $InitializeCommonEvent(0, 90005783, 1045520800, 1045522170, 1045522171, 1045520730, 1045522730, 1045522732, 0);
    $InitializeCommonEvent(0, 90005790, 0, 1045520180, 1045522181, 1045522182, 1045520705, 23, 1045522180, 1044522181, 0, 35009315, false, 0);
    $InitializeCommonEvent(0, 90005791, 1045520180, 1045522181, 1045522182, 1045520705);
    $InitializeCommonEvent(0, 90005792, 1045520180, 1045522181, 1045522182, 1045520705, 113800, 0);
    $InitializeCommonEvent(0, 90005793, 1045520180, 1045522181, 1045522182, 1045520705, 1045522180, 0, 0);
    $InitializeEvent(0, 1045520700);
    $InitializeEvent(0, 1045520710);
    $InitializeEvent(0, 1045520720);
});

// プリコンストラクタ -- preconstructor
$Event(50, Default, function() {
    SetCharacterBackreadState(1045520700, true);
    SetCharacterBackreadState(1045520701, true);
    SetCharacterBackreadState(1045520705, true);
});

// 高路のガーディアン_視覚聴覚を鈍らせる -- Guardian of the High Road_Deduens visual and hearing
$Event(1045522200, Restart, function() {
    EndIf(EventFlag(1045520200));
    WaitFor(AllPlayersInArea(1045522182));
    SetSpEffect(1045520200, 8082);
    ClearCharactersAITarget(1045520200);
});

// 王都の封印 -- Seal of the Royal Capital
$Event(1045522500, Restart, function() {
    if (EventFlag(1045520500)) {
        DisableAsset(1045521500);
        EndEvent();
    }
L0:
    if (PlayerIsInOwnWorld()) {
        if (!EventFlag(1045522550)) {
            DeleteAssetfollowingSFX(1045521500, true);
            CreateAssetfollowingSFX(1045521500, 101, 1540);
            SetNetworkconnectedEventFlagID(1045522550, ON);
        }
L2:
        onlineAct = PlayerIsInOwnWorld() && ActionButtonInArea(9503, 1045521500);
        // entrance into capital
        //flag = EventFlag(11104088) && EventFlag(105);
        flag = EventFlag(105);
        WaitFor(onlineAct || flag);
        if (!flag.Passed) {
            DisplayGenericDialog(20003, PromptType.YESNO, NumberofOptions.NoButtons, 1045521500, 3);
            WaitFixedTimeSeconds(1);
            RestartEvent();
        }
L3:
        SetNetworkconnectedEventFlagID(1045520500, ON);
        DeleteAssetfollowingSFX(1045521500, true);
        DisableAsset(1045521500);
        EndEvent();
    }
L1:
    DeleteAssetfollowingSFX(1045521500, true);
    CreateAssetfollowingSFX(1045521500, 101, 1540);
    EndEvent();
});

// NPC331ならず者_椅子への位置合わせ -- NPC331 Rogue_Alignment to chair
$Event(1045520700, Restart, function() {
    EnableAssetInvunerability(1045521700);
    DisableCharacterGravity(1045520700);
    DisableCharacterCollision(1045520700);
    ForceAnimationPlayback(1045520700, 90101, false, false, false);
    IssueShortWarpRequest(1045520700, TargetEntityType.Area, 1045522700, -1);
});

// NPC348マレニアの娘_神肌_ツリガ_ガーゴイル_白霊召喚停止イベント -- NPC348 Marenia's Daughter_Divine Skin_Tsuriga_Gargoyle_White Spirit Summoning Stop Event
$Event(1045520710, Restart, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(!AnyBatchEventFlags(1042559207, 1042559209));
    WaitFor(AnyBatchEventFlags(4181, 4183));
    BatchSetNetworkconnectedEventFlags(1042559207, 1042559209, OFF);
    EndEvent();
});

// NPC344_トラゴス_白霊共闘許可フラグ立て -- NPC344_Tragos_White spirit cooperation permission flag setting
$Event(1045520720, Restart, function() {
    WaitFixedTimeFrames(1);
    SetEventFlagID(1045529250, OFF);
    EndIf(EventFlag(1045520800));
    EndIf(EventFlag(7606));
    SetEventFlagID(1045529250, ON);
    EndEvent();
});

// プリコンストラクタ_LOD1 -- Preconstructor_LOD1
$Event(150, Default, function() {
    $InitializeCommonEvent(0, 90005485, 1045520202);
});
