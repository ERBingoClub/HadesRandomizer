// ==EMEVD==
// @docs    er-common.emedf.json
// @compress    DCX_KRAK
// @game    Sekiro
// @string    "N:\\GR\\data\\Param\\event\\common_func.emevd\u0000N:\\GR\\data\\Param\\event\\common_macro.emevd\u0000\u0000\u0000\u0000\u0000\u0000"
// @linked    [0,82]
// @version    3.6.1
// ==/EMEVD==

$Event(0, Default, function() {
    RegisterBonfire(2046400000, 2046401950, 0, 0, 0, 0);
    RegisterBonfire(2046400001, 2046401951, 0, 0, 0, 0); // Gravesite Hollow
    $InitializeCommonEvent(0, 90005511, 2046400066, 2046400022, 2046400044, 464035, 0); // Register Door
    $InitializeCommonEvent(0, 90005512, 2046400066, 2046400033, 2046400055);
    $InitializeCommonEvent(0, 90005870, 2046400800, 905730600, 16);
    $InitializeCommonEvent(0, 90005860, 2046400800, 0, 2046400800, 0, 30845, 0);
    $InitializeCommonEvent(0, 90005201, 2046400300, 30000, 20000, 45, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005250, 2046400301, 2046402301, 0, 0);
    $InitializeEvent(0, 2046402200, 2046400200, 2046402200, 2046402201);
    $InitializeEvent(1, 2046402200, 2046400201, 2046402200, 2046402202);
    $InitializeEvent(2, 2046402200, 2046400202, 2046402200, 2046402203);
    $InitializeEvent(0, 2046402550, 580100, 2046401550, 80100);
    $InitializeEvent(0, 2046400700, 4926, 4458);
    $InitializeEvent(0, 2046400600);
});

$Event(50, Default, function() {
    $InitializeEvent(0, 2046402500);
    $InitializeEvent(0, 2046402502);
});

// initialization
$Event(2046400600, Default, function() {
    EndIf(ThisEventSlot());
    
    // The default respawn point is Chapel of Anticipation. This line changes it to Gravesite Hollow.
    SetPlayerRespawnPoint(2046402020);
    
    const initialFlags = [
        // STORY FLAGS
        100, // Story: Start
        //102, // Story: Reached Limgrave
        //104, // Story: Reached Roundtable Hold
        4680, // Allow Leveling Up at Grace
        4681, // Accepted Melina's Request to take her to the Erdtree. Prevents her from appearing at Gatefront area graces
        //11108548, // Roundtable Door is opened
        
        // MAP RELATED
        62000, // Allow Map Display
        82002, // DLC map can be opened
        
        // Initial Graces
        //71190, // Roundtable Hold
        76806, // Gravesite Hollow
        
        // MAPS
        62084, // Abyss
        62083, // Rauh Ruins
        62082, // Southern Shore
        62081, // Scadu Altus
        62080, // Gravesite Plain
        
        // MAP ICONS (Base Game Only)
        62100, 62300, 62820, 62700, 62200, 62550, 62551, 62360, 62101, 62102, 62880, 62881, 62890, 62891,
        62980, 62981, 62870, 62871, 62860, 62150, 62151, 62103, 62202, 62105, 62201, 62203, 62314, 62310,
        62311, 62312, 62104, 62313, 62315, 62410, 62411, 62412, 62510, 62511, 62512, 62560, 62152, 62153,
        62106, 62107, 62204, 62205, 62206, 62316, 662201, 62203, 62314, 62310, 62311, 62312, 62104, 62313,
        62315, 62410, 62411, 62412, 62510, 62511, 62512, 62560, 62152, 62153, 62106, 62107, 62204, 62205,
        62206, 62316, 62317, 62413, 62460, 62513, 62108, 62109, 62318, 62319, 62414, 62415, 62514, 62154,
        62110, 62207, 62320, 62322, 62416, 62417, 62515, 62111, 62208, 62209, 62321, 62323, 622317, 62413,
        62460, 62513, 62108, 62109, 62318, 62319, 62414, 62415, 62514, 62154, 62110, 62207, 62320, 62322,
        62416, 62417, 62515, 62111, 62208, 62209, 62321, 62323, 62461, 62516, 62710, 62324, 62325, 62823,
        62915, 62965, 62800, 62916, 62850, 62822, 62918, 62943, 62917, 62919, 62821, 62720, 62730, 62740,
        62173, 62170, 62180, 62121, 62130, 62177, 62178, 62181, 62120, 62126, 62132, 62138, 62129, 62183,
        62184, 62171, 62182, 62125, 62172, 62174, 62133, 62176, 62131, 62124, 62128, 62175, 62134, 62123,
        62137, 62127, 62135, 62122, 62283, 62281, 62248, 62231, 62238, 62252, 62282, 62284, 62241, 62251,
        62226, 62243, 62244, 62254, 62245, 62285, 62232, 62280, 62222, 62242, 62247, 62228, 62229, 62223,
        62239, 62227, 62250, 62221, 62224, 62237, 62235, 62230, 62240, 62253, 62233, 62249, 62236, 62220,
        62225, 62234, 62246, 62383, 62348, 62386, 62389, 62331, 62382, 62384, 62330, 62335, 62385, 62381,
        62344, 62332, 62342, 62345, 62336, 62380, 62338, 62334, 62346, 62341, 62339, 62340, 62343, 62333,
        62337, 62347, 62420, 62427, 62424, 62429, 62423, 62437, 62426, 62421, 62425, 62470, 62430, 62432,
        62471, 62434, 62428, 62422, 62435, 62436, 62438, 62473, 62474, 62475, 62472, 62571, 62570, 62572,
        62522, 62528, 62524, 62574, 62573, 62521, 62523, 62529, 62527, 62530, 62526, 62525, 62531, 62520,
        62610, 62620, 62621, 62622, 62631, 62632, 62633, 62634, 62640, 62630,
        
        // MAP ICONS (DLC only)
        62811, 62806, 62843, 62809, 62815, 62812, 62805, 62810, 62813, 62814, 62807, 62830, 62831, 62842,
        62841, 62808, 62826, 62825, 62855, 62827, 62840, 62844, 62865, 62920, 62921, 62950, 62904, 62905,
        62900, 62901, 62902, 62903, 62907, 62931, 62932, 62909, 62910, 62962, 62960, 62970, 62961, 62906,
        62911, 62908, 62912, 62941, 62942,
    ];
    
    for (let i = 0; i < initialFlags.length; i++) {
        SetEventFlagID(initialFlags[i], ON);
    }
    
    // spirit-calling bell
    SetEventFlagID(60110, ON);
    DirectlyGivePlayerItem(ItemType.Goods, 8158, 6001, 1);
    
    // finger severer
    SetEventFlagID(60310, ON);
    DirectlyGivePlayerItem(ItemType.Goods, 103, 6001, 1);
    
    // tarnished's furled finger
    DirectlyGivePlayerItem(ItemType.Goods, 100, 6001, 1);
    
    // talisman pouches
    SetEventFlagID(60500, ON);
    SetEventFlagID(60510, ON);
    SetEventFlagID(60520, ON);
    RemoveItemFromPlayer(ItemType.Goods, 10040, 3);
    for (let i = 0; i < 3; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 10040, 6001, 1);
    }
    
    // give cracked pots
    for (let i = 0; i < 20; i++) {
        SetEventFlagID(66000 + (i*10), ON);   
    }
    RemoveItemFromPlayer(ItemType.Goods, 9500, 20);
    for (let i = 0; i < 20; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 9500, 6001, 1);
    }
    
    // give memory stones
    for (let i = 0; i < 8; i++) {
        SetEventFlagID(60400 + (i*10), ON);   
    }
    RemoveItemFromPlayer(ItemType.Goods, 10030, 8);
    for (let i = 0; i < 8; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 10030, 6001, 1);
    }
    
    // give perfume bottles
    for (let i = 0; i < 10; i++) {
        SetEventFlagID(66700 + (i*10), ON);   
    }
    RemoveItemFromPlayer(ItemType.Goods, 9510, 10);
    for (let i = 0; i < 10; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 9510, 6001, 1);
    }
    
    // estus flasks
    SetEventFlagID(60000, ON);
    for (let i = 0; i <= 25; i++) {
        RemoveItemFromPlayer(ItemType.Goods, 1000 + i, 14);
        RemoveItemFromPlayer(ItemType.Goods, 1050 + i, 14);
    }
    for (let i = 0; i < 6; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 1017, 6001, 1);
    }
    for (let i = 0; i < 1; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 1067, 6001, 1);
    }
    
    // physick flask
    SetEventFlagID(60020, ON);
    RemoveItemFromPlayer(ItemType.Goods, 250, 1);
    DirectlyGivePlayerItem(ItemType.Goods, 250, 6001, 1);
    
    // steed whistle
    SetEventFlagID(60100, ON);
    RemoveItemFromPlayer(ItemType.Goods, 130, 1);
    DirectlyGivePlayerItem(ItemType.Goods, 130, 6001, 1);
    
    // give crafting kit
    SetEventFlagID(60120, ON);
    DirectlyGivePlayerItem(ItemType.Goods, 8500, 6001, 1);
    
    // give whetstone knife
    SetEventFlagID(60130, ON);
    DirectlyGivePlayerItem(ItemType.Goods, 8590, 6001, 1);
    
    // give lantern
    DirectlyGivePlayerItem(ItemType.Goods, 2070, 6001, 1);
    
    // give starlight shards
    for (let i = 0; i < 3; i++ ) {
        DirectlyGivePlayerItem(ItemType.Goods, 1290, 6001, 1);
    }
    
    SetThisEventSlot(ON);
});

$Event(2046400700, Restart, function(eventFlagId, eventFlagId2) {
    EndIf(!PlayerIsInOwnWorld());
    WaitFixedTimeFrames(1);
    EndIf(EventFlag(eventFlagId));
    SetEventFlagID(eventFlagId, ON);
    SetEventFlagID(eventFlagId2, ON);
});

$Event(2046402500, Restart, function() {
    EndIf(EventFlag(2046400500));
    EndIf(!PlayerInMap(61, 46, 40, 0));
    SetCurrentTime(8, 0, 0, false, false, false, 0, 0, 0);
    FreezeTime(true);
    WaitFor((PlayerIsInOwnWorld() && !InArea(10000, 2046402500)) || !PlayerIsInOwnWorld());
    if (PlayerIsInOwnWorld()) {
        SetNetworkconnectedEventFlagID(2046400500, ON);
    }
L1:
    FreezeTime(false);
});

$Event(2046402502, Restart, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(2046400502));
    EndIf(!PlayerInMap(61, 46, 40, 0));
    DisableAreaWelcomeMessage();
    WaitFor(PlayerIsInOwnWorld() && !InArea(10000, 2046402502));
    EnableAreaWelcomeMessage();
    DisplayAreaWelcomeMessage(68000);
    SetEventFlagID(2046400502, ON);
});

$Event(2046402200, Restart, function(chrEntityId, areaEntityId, entityId) {
    DisableNetworkSync();
    CreateBulletOwner(chrEntityId);
    WaitFor(InArea(10000, areaEntityId));
    WaitRandomTimeSeconds(1, 10);
    if (!EventFlag(70)) {
        if (EventFlag(50)) {
            ShootBullet(chrEntityId, entityId, 900, 804508000, 0, 0, 0);
        }
        if (EventFlag(51)) {
            ShootBullet(chrEntityId, entityId, 900, 804508010, 0, 0, 0);
        }
        if (EventFlag(52)) {
            ShootBullet(chrEntityId, entityId, 900, 804508020, 0, 0, 0);
        }
        if (EventFlag(53)) {
            ShootBullet(chrEntityId, entityId, 900, 804508030, 0, 0, 0);
        }
        if (EventFlag(54)) {
            ShootBullet(chrEntityId, entityId, 900, 804508040, 0, 0, 0);
        }
        if (EventFlag(55)) {
            ShootBullet(chrEntityId, entityId, 900, 804508050, 0, 0, 0);
        }
        if (EventFlag(56)) {
            ShootBullet(chrEntityId, entityId, 900, 804508060, 0, 0, 0);
        }
        if (EventFlag(57)) {
            ShootBullet(chrEntityId, entityId, 900, 804508070, 0, 0, 0);
        }
    } else {
L0:
        if (EventFlag(50)) {
            ShootBullet(chrEntityId, entityId, 900, 804518000, 0, 0, 0);
        }
        if (EventFlag(51)) {
            ShootBullet(chrEntityId, entityId, 900, 804518010, 0, 0, 0);
        }
        if (EventFlag(52)) {
            ShootBullet(chrEntityId, entityId, 900, 804518020, 0, 0, 0);
        }
        if (EventFlag(53)) {
            ShootBullet(chrEntityId, entityId, 900, 804518030, 0, 0, 0);
        }
        if (EventFlag(54)) {
            ShootBullet(chrEntityId, entityId, 900, 804518040, 0, 0, 0);
        }
        if (EventFlag(55)) {
            ShootBullet(chrEntityId, entityId, 900, 804518050, 0, 0, 0);
        }
        if (EventFlag(56)) {
            ShootBullet(chrEntityId, entityId, 900, 804518060, 0, 0, 0);
        }
        if (EventFlag(57)) {
            ShootBullet(chrEntityId, entityId, 900, 804518070, 0, 0, 0);
        }
    }
L1:
    WaitFixedTimeSeconds(1);
    RestartEvent();
});

$Event(2046402550, Restart, function(eventFlagId, assetEntityId, itemLotId) {
    EndIf(EventFlag(eventFlagId));
    EndIf(!PlayerIsInOwnWorld());
    DeleteAssetfollowingSFX(assetEntityId, false);
    CreateAssetfollowingSFX(assetEntityId, 200, 806845);
    WaitFor(PlayerIsInOwnWorld() && ActionButtonInArea(9310, assetEntityId));
    DeleteAssetfollowingSFX(assetEntityId, true);
    PlaySE(assetEntityId, SoundType.SFX, 806841);
    WaitFixedTimeSeconds(0.1);
    AwardItemsIncludingClients(itemLotId);
});
