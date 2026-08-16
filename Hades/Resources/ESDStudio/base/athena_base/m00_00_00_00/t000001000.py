# -*- coding: utf-8 -*-
def t000001000_1():
    """State 0,1"""
    t000001000_x22()
    Quit()

def t000001000_x0(action7=_):
    """State 0,1"""
    OpenGenericDialog(8, action7, 3, 4, 2)
    assert not CheckSpecificPersonGenericDialogIsOpen(0)
    """State 2"""
    if GetGenericDialogButtonResult() == 1:
        """State 3"""
        return 0
    else:
        """State 4"""
        return 1

def t000001000_x1():
    """State 0,1"""
    if not CheckSpecificPersonTalkHasEnded(0):
        """State 7"""
        ClearTalkProgressData()
        StopEventAnimWithoutForcingConversationEnd(0)
        """State 6"""
        ReportConversationEndToHavokBehavior()
    else:
        pass
    """State 2"""
    if CheckSpecificPersonGenericDialogIsOpen(0):
        """State 3"""
        ForceCloseGenericDialog()
    else:
        pass
    """State 4"""
    if CheckSpecificPersonMenuIsOpen(-1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0):
        """State 5"""
        ForceCloseMenu()
    else:
        pass
    """State 8"""
    return 0

def t000001000_x2():
    """State 0,1"""
    ClearTalkProgressData()
    StopEventAnimWithoutForcingConversationEnd(0)
    ForceCloseGenericDialog()
    ForceCloseMenu()
    ReportConversationEndToHavokBehavior()
    """State 2"""
    return 0

def t000001000_x3(actionbutton1=_, flag8=6001, flag9=6000):
    """State 0"""
    while True:
        """State 1"""
        assert not GetOneLineHelpStatus() and not IsClientPlayer() and not IsPlayerDead() and not IsCharacterDisabled()
        """State 2"""
        assert CompareBonfireState(1)
        """State 4"""
        if GetEventFlag(flag9):
            """State 5"""
            assert GetEventFlag(flag8) and not GetEventFlag(flag9)
            """State 6"""
            assert GetCurrentStateElapsedTime() > 1
        elif GetEventFlag(flag8) and not GetEventFlag(flag9):
            pass
        """State 3"""
        if CompareBonfireState(0):
            pass
        elif CheckActionButtonArea(actionbutton1):
            break
        elif (not (not GetOneLineHelpStatus() and not IsClientPlayer() and not IsPlayerDead() and not IsCharacterDisabled())
              or (not GetEventFlag(flag8) or GetEventFlag(flag9))):
            pass
    """State 7"""
    return 0

def t000001000_x4(action6=_):
    """State 0,1"""
    OpenGenericDialog(7, action6, 1, 0, 1)
    assert not CheckSpecificPersonGenericDialogIsOpen(0)
    """State 2"""
    return 0

def t000001000_x5(actionbutton5=6100, flag6=6001, flag7=6000):
    """State 0"""
    while True:
        """State 1"""
        assert not GetOneLineHelpStatus() and not IsClientPlayer() and not IsPlayerDead() and not IsCharacterDisabled()
        """State 3"""
        assert GetEventFlag(flag6) and not GetEventFlag(flag7)
        """State 2"""
        # actionbutton:6100:"Touch grace"
        if CheckActionButtonArea(actionbutton5):
            break
        elif (not (not GetOneLineHelpStatus() and not IsClientPlayer() and not IsPlayerDead() and not IsCharacterDisabled())
              or (not GetEventFlag(flag6) or GetEventFlag(flag7))):
            pass
    """State 4"""
    return 0

def t000001000_x6(goods7=1000, goods8=10020):
    """State 0,14"""
    if GetEventFlag(720080):
        """State 15"""
        pass
    else:
        """State 16,17"""
        SetEventFlag(720080, 1)
    """State 1"""
    if GetTotalBonfireLevel() <= 13:
        """State 2,13,26"""
        # goods:1000:Flask of Crimson Tears
        # goods:1001:Flask of Crimson Tears
        # goods:1002:Flask of Crimson Tears +1
        # goods:1003:Flask of Crimson Tears +1
        # goods:1004:Flask of Crimson Tears +2
        # goods:1005:Flask of Crimson Tears +2
        # goods:1006:Flask of Crimson Tears +3
        # goods:1007:Flask of Crimson Tears +3
        # goods:1008:Flask of Crimson Tears +4
        # goods:1009:Flask of Crimson Tears +4
        # goods:1010:Flask of Crimson Tears +5
        # goods:1011:Flask of Crimson Tears +5
        # goods:1012:Flask of Crimson Tears +6
        # goods:1013:Flask of Crimson Tears +6
        # goods:1014:Flask of Crimson Tears +7
        # goods:1015:Flask of Crimson Tears +7
        # goods:1016:Flask of Crimson Tears +8
        # goods:1017:Flask of Crimson Tears +8
        # goods:1018:Flask of Crimson Tears +9
        # goods:1019:Flask of Crimson Tears +9
        # goods:1020:Flask of Crimson Tears +10
        # goods:1021:Flask of Crimson Tears +10
        # goods:1022:Flask of Crimson Tears +11
        # goods:1023:Flask of Crimson Tears +11
        # goods:1024:Flask of Crimson Tears +12
        # goods:1025:Flask of Crimson Tears +12
        call = t000001000_x17(goods7=goods7, goods10=0, z44=1)
        if call.Get() == 0:
            """State 12,25"""
            # action:13040150:"No Flask of Crimson Tears in inventory"
            assert t000001000_x4(action6=13040150)
        elif call.Done():
            """State 11,19"""
            SetWorkValue(1, 1)
            """State 20,6,10"""
            # goods:10020:Sacred Tear
            if (ComparePlayerInventoryNumber(3, goods8, 4, GetWorkValue(1),
                False)):
                """State 4,8"""
                BonfireActivation(GetTotalBonfireLevel() + 1)
                """State 9"""
                # goods:10020:Sacred Tear
                PlayerEquipmentQuantityChange(3, goods8, GetWorkValue(1) * -1)
                """State 27"""
                assert t000001000_x19(goods7=goods7)
                """State 24"""
                assert t000001000_x16(goods9=goods7)
                """State 22"""
                # action:13040020:"Increased the amount of HP/FP replenished by your flasks"
                assert t000001000_x4(action6=13040020)
                """State 18"""
                SetWorkValue(1, 0)
            else:
                """State 5,28"""
                # action:20011000:"No Sacred Tear in inventory"
                assert t000001000_x4(action6=20011000)
    else:
        """State 3,21"""
        # action:13040000:"The amount of HP/FP your flasks replenish cannot be increased any further"
        assert t000001000_x4(action6=13040000)
    """State 29"""
    return 0
    """Unused"""
    """State 23"""
    t000001000_x11()
    Quit()

def t000001000_x7(goods5=1000, goods6=10010):
    """State 0,15"""
    if GetEventFlag(720070):
        """State 16"""
        pass
    else:
        """State 17,18"""
        SetEventFlag(720070, 1)
    """State 1"""
    if GetEstusAllocation(0) + GetEstusAllocation(1) < 13:
        """State 2,13,26"""
        # goods:1000:Flask of Crimson Tears
        # goods:1001:Flask of Crimson Tears
        # goods:1002:Flask of Crimson Tears +1
        # goods:1003:Flask of Crimson Tears +1
        # goods:1004:Flask of Crimson Tears +2
        # goods:1005:Flask of Crimson Tears +2
        # goods:1006:Flask of Crimson Tears +3
        # goods:1007:Flask of Crimson Tears +3
        # goods:1008:Flask of Crimson Tears +4
        # goods:1009:Flask of Crimson Tears +4
        # goods:1010:Flask of Crimson Tears +5
        # goods:1011:Flask of Crimson Tears +5
        # goods:1012:Flask of Crimson Tears +6
        # goods:1013:Flask of Crimson Tears +6
        # goods:1014:Flask of Crimson Tears +7
        # goods:1015:Flask of Crimson Tears +7
        # goods:1016:Flask of Crimson Tears +8
        # goods:1017:Flask of Crimson Tears +8
        # goods:1018:Flask of Crimson Tears +9
        # goods:1019:Flask of Crimson Tears +9
        # goods:1020:Flask of Crimson Tears +10
        # goods:1021:Flask of Crimson Tears +10
        # goods:1022:Flask of Crimson Tears +11
        # goods:1023:Flask of Crimson Tears +11
        # goods:1024:Flask of Crimson Tears +12
        # goods:1025:Flask of Crimson Tears +12
        call = t000001000_x17(goods7=goods5, goods10=0, z44=1)
        if call.Get() == 0:
            """State 12,25"""
            # action:13040150:"No Flask of Crimson Tears in inventory"
            assert t000001000_x4(action6=13040150)
        elif call.Done():
            """State 11,19"""
            SetWorkValue(1, GetEstusAllocation(0) + GetEstusAllocation(1) + -4)
            """State 28"""
            assert t000001000_x21(z31=1, z32=1, z33=2, z34=2, z35=3, z36=3, z37=4, z38=4, z39=5, z40=5, z41=1)
            """State 21,6,14"""
            # goods:10010:Golden Seed
            if (ComparePlayerInventoryNumber(3, goods6, 4, GetWorkValue(1),
                False)):
                """State 4,8"""
                # goods:10010:Golden Seed
                PlayerEquipmentQuantityChange(3, goods6, GetWorkValue(1) * -1)
                """State 9"""
                EstusAllocationUpdate(GetEstusAllocation(0) + 1, 0)
                """State 27"""
                assert t000001000_x16(goods9=goods5)
                """State 22"""
                # action:13040140:"Added a charge to Flask of Crimson Tears"
                assert t000001000_x4(action6=13040140)
                """State 20"""
                SetWorkValue(1, 0)
                """State 10"""
            else:
                """State 5,23"""
                # action:20011010:"Not enough Golden Seeds"
                assert t000001000_x4(action6=20011010)
    else:
        """State 3,24"""
        # action:13040120:"Flask charges already at maximum"
        assert t000001000_x4(action6=13040120)
    """State 29"""
    return 0

def t000001000_x8(goods11=1000):
    """State 0,1"""
    # goods:1001:Flask of Crimson Tears
    # goods:1000:Flask of Crimson Tears
    if (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 0 * 2) or DoesPlayerHaveItem(3,
        goods11 + 0 + 0 * 50 + 0 * 2)):
        """State 2"""
        BonfireActivation(1)
        """State 13"""
        Label('L0')
        """State 18"""
        assert t000001000_x9(goods11=goods11)
    # goods:1003:Flask of Crimson Tears +1
    # goods:1002:Flask of Crimson Tears +1
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 1 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 1 * 2)):
        """State 3"""
        BonfireActivation(2)
        Goto('L0')
    # goods:1005:Flask of Crimson Tears +2
    # goods:1004:Flask of Crimson Tears +2
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 2 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 2 * 2)):
        """State 4"""
        BonfireActivation(3)
        Goto('L0')
    # goods:1007:Flask of Crimson Tears +3
    # goods:1006:Flask of Crimson Tears +3
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 3 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 3 * 2)):
        """State 5"""
        BonfireActivation(4)
        Goto('L0')
    # goods:1009:Flask of Crimson Tears +4
    # goods:1008:Flask of Crimson Tears +4
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 4 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 4 * 2)):
        """State 6"""
        BonfireActivation(5)
        Goto('L0')
    # goods:1011:Flask of Crimson Tears +5
    # goods:1010:Flask of Crimson Tears +5
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 5 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 5 * 2)):
        """State 7"""
        BonfireActivation(6)
        Goto('L0')
    # goods:1013:Flask of Crimson Tears +6
    # goods:1012:Flask of Crimson Tears +6
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 6 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 6 * 2)):
        """State 8"""
        BonfireActivation(7)
        Goto('L0')
    # goods:1015:Flask of Crimson Tears +7
    # goods:1014:Flask of Crimson Tears +7
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 7 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 7 * 2)):
        """State 9"""
        BonfireActivation(8)
        Goto('L0')
    # goods:1017:Flask of Crimson Tears +8
    # goods:1016:Flask of Crimson Tears +8
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 8 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 8 * 2)):
        """State 10"""
        BonfireActivation(9)
        Goto('L0')
    # goods:1019:Flask of Crimson Tears +9
    # goods:1018:Flask of Crimson Tears +9
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 9 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 9 * 2)):
        """State 11"""
        BonfireActivation(10)
        Goto('L0')
    # goods:1021:Flask of Crimson Tears +10
    # goods:1020:Flask of Crimson Tears +10
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 10 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 10 * 2)):
        """State 12"""
        BonfireActivation(11)
        Goto('L0')
    elif True:
        """State 15"""
        pass
    # goods:1023:Flask of Crimson Tears +11
    # goods:1022:Flask of Crimson Tears +11
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 11 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 11 * 2)):
        """State 16"""
        BonfireActivation(12)
        Goto('L0')
    # goods:1025:Flask of Crimson Tears +12
    # goods:1024:Flask of Crimson Tears +12
    elif (DoesPlayerHaveItem(3, goods11 + 1 + 0 * 50 + 12 * 2) or DoesPlayerHaveItem(3,
          goods11 + 0 + 0 * 50 + 12 * 2)):
        """State 17"""
        BonfireActivation(13)
        Goto('L0')
    """State 14,19"""
    return 0

def t000001000_x9(goods11=1000):
    """State 0,15"""
    # goods:1000:Flask of Crimson Tears
    # goods:1002:Flask of Crimson Tears +1
    # goods:1004:Flask of Crimson Tears +2
    # goods:1006:Flask of Crimson Tears +3
    # goods:1008:Flask of Crimson Tears +4
    # goods:1010:Flask of Crimson Tears +5
    # goods:1012:Flask of Crimson Tears +6
    # goods:1014:Flask of Crimson Tears +7
    call = t000001000_x12(goods11=goods11, goods12=0, goods13=0)
    if call.Get() == 1:
        """State 1,11"""
        # goods:1000:Flask of Crimson Tears
        # goods:1002:Flask of Crimson Tears +1
        # goods:1004:Flask of Crimson Tears +2
        # goods:1006:Flask of Crimson Tears +3
        # goods:1008:Flask of Crimson Tears +4
        # goods:1010:Flask of Crimson Tears +5
        # goods:1012:Flask of Crimson Tears +6
        # goods:1014:Flask of Crimson Tears +7
        # goods:1016:Flask of Crimson Tears +8
        # goods:1018:Flask of Crimson Tears +9
        assert t000001000_x10(goods11=goods11, goods14=0, goods15=0)
    elif call.Done():
        """State 16"""
        # goods:1001:Flask of Crimson Tears
        # goods:1003:Flask of Crimson Tears +1
        # goods:1005:Flask of Crimson Tears +2
        # goods:1007:Flask of Crimson Tears +3
        # goods:1009:Flask of Crimson Tears +4
        # goods:1011:Flask of Crimson Tears +5
        # goods:1013:Flask of Crimson Tears +6
        # goods:1015:Flask of Crimson Tears +7
        call = t000001000_x12(goods11=goods11, goods12=0, goods13=1)
        if call.Get() == 1:
            """State 8,10"""
            # goods:1001:Flask of Crimson Tears
            # goods:1003:Flask of Crimson Tears +1
            # goods:1005:Flask of Crimson Tears +2
            # goods:1007:Flask of Crimson Tears +3
            # goods:1009:Flask of Crimson Tears +4
            # goods:1011:Flask of Crimson Tears +5
            # goods:1013:Flask of Crimson Tears +6
            # goods:1015:Flask of Crimson Tears +7
            # goods:1017:Flask of Crimson Tears +8
            # goods:1019:Flask of Crimson Tears +9
            assert t000001000_x10(goods11=goods11, goods14=0, goods15=1)
        elif call.Done():
            """State 2"""
            pass
    """State 5,17"""
    # goods:1050:Flask of Cerulean Tears
    # goods:1052:Flask of Cerulean Tears +1
    # goods:1054:Flask of Cerulean Tears +2
    # goods:1056:Flask of Cerulean Tears +3
    # goods:1058:Flask of Cerulean Tears +4
    # goods:1060:Flask of Cerulean Tears +5
    # goods:1062:Flask of Cerulean Tears +6
    # goods:1064:Flask of Cerulean Tears +7
    call = t000001000_x12(goods11=goods11, goods12=1, goods13=0)
    if call.Get() == 1:
        """State 3,13"""
        # goods:1050:Flask of Cerulean Tears
        # goods:1052:Flask of Cerulean Tears +1
        # goods:1054:Flask of Cerulean Tears +2
        # goods:1056:Flask of Cerulean Tears +3
        # goods:1058:Flask of Cerulean Tears +4
        # goods:1060:Flask of Cerulean Tears +5
        # goods:1062:Flask of Cerulean Tears +6
        # goods:1064:Flask of Cerulean Tears +7
        # goods:1066:Flask of Cerulean Tears +8
        # goods:1068:Flask of Cerulean Tears +9
        assert t000001000_x10(goods11=goods11, goods14=1, goods15=0)
    elif call.Done():
        """State 18"""
        # goods:1051:Flask of Cerulean Tears
        # goods:1053:Flask of Cerulean Tears +1
        # goods:1055:Flask of Cerulean Tears +2
        # goods:1057:Flask of Cerulean Tears +3
        # goods:1059:Flask of Cerulean Tears +4
        # goods:1061:Flask of Cerulean Tears +5
        # goods:1063:Flask of Cerulean Tears +6
        # goods:1065:Flask of Cerulean Tears +7
        call = t000001000_x12(goods11=goods11, goods12=1, goods13=1)
        if call.Get() == 1:
            """State 9,12"""
            # goods:1051:Flask of Cerulean Tears
            # goods:1053:Flask of Cerulean Tears +1
            # goods:1055:Flask of Cerulean Tears +2
            # goods:1057:Flask of Cerulean Tears +3
            # goods:1059:Flask of Cerulean Tears +4
            # goods:1061:Flask of Cerulean Tears +5
            # goods:1063:Flask of Cerulean Tears +6
            # goods:1065:Flask of Cerulean Tears +7
            # goods:1067:Flask of Cerulean Tears +8
            # goods:1069:Flask of Cerulean Tears +9
            assert t000001000_x10(goods11=goods11, goods14=1, goods15=1)
        elif call.Done():
            """State 4"""
            pass
    """State 6,14"""
    assert t000001000_x11()
    """State 7,19"""
    return 0

def t000001000_x10(goods11=1000, goods14=_, goods15=_):
    """State 0,1"""
    if DoesPlayerHaveItem(3, goods11 + goods15 + goods14 * 50 + 0 * 2):
        """State 3"""
        ReplaceTool(goods11 + goods14 * 50 + 0 * 2 + goods15, goods11 + goods14 * 50 + goods15 + 2 * (GetTotalBonfireLevel() - 1),
                    1)
    elif DoesPlayerHaveItem(3, goods11 + goods15 + goods14 * 50 + 1 * 2):
        """State 4"""
        ReplaceTool(goods11 + goods14 * 50 + 1 * 2 + goods15, goods11 + goods14 * 50 + goods15 + 2 * (GetTotalBonfireLevel() - 1),
                    1)
    elif DoesPlayerHaveItem(3, goods11 + goods15 + goods14 * 50 + 2 * 2):
        """State 5"""
        ReplaceTool(goods11 + goods14 * 50 + 2 * 2 + goods15, goods11 + goods14 * 50 + goods15 + 2 * (GetTotalBonfireLevel() - 1),
                    1)
    elif DoesPlayerHaveItem(3, goods11 + goods15 + goods14 * 50 + 3 * 2):
        """State 6"""
        ReplaceTool(goods11 + goods14 * 50 + 3 * 2 + goods15, goods11 + goods14 * 50 + goods15 + 2 * (GetTotalBonfireLevel() - 1),
                    1)
    elif DoesPlayerHaveItem(3, goods11 + goods15 + goods14 * 50 + 4 * 2):
        """State 7"""
        ReplaceTool(goods11 + goods14 * 50 + 4 * 2 + goods15, goods11 + goods14 * 50 + goods15 + 2 * (GetTotalBonfireLevel() - 1),
                    1)
    elif DoesPlayerHaveItem(3, goods11 + goods15 + goods14 * 50 + 5 * 2):
        """State 8"""
        ReplaceTool(goods11 + goods14 * 50 + 5 * 2 + goods15, goods11 + goods14 * 50 + goods15 + 2 * (GetTotalBonfireLevel() - 1),
                    1)
    elif DoesPlayerHaveItem(3, goods11 + goods15 + goods14 * 50 + 6 * 2):
        """State 9"""
        ReplaceTool(goods11 + goods14 * 50 + 6 * 2 + goods15, goods11 + goods14 * 50 + goods15 + 2 * (GetTotalBonfireLevel() - 1),
                    1)
    else:
        """State 2"""
        pass
    """State 13"""
    return 0
    """Unused"""
    """State 10"""
    ReplaceTool(goods11 + goods14 * 50 + 7 * 2 + goods15, goods11 + goods14 * 50 + goods15 + 2 * (GetTotalBonfireLevel() - 1),
                1)
    Quit()
    """State 11"""
    ReplaceTool(goods11 + goods14 * 50 + 8 * 2 + goods15, goods11 + goods14 * 50 + goods15 + 2 * (GetTotalBonfireLevel() - 1),
                1)
    Quit()
    """State 12"""
    ReplaceTool(goods11 + goods14 * 50 + 9 * 2 + goods15, goods11 + goods14 * 50 + goods15 + 2 * (GetTotalBonfireLevel() - 1),
                1)
    Quit()

def t000001000_x11():
    """State 0,1,13,14"""
    return 0
    """Unused"""
    """State 2,3,4"""
    Quit()
    """State 5"""
    Quit()
    """State 6"""
    Quit()
    """State 7"""
    Quit()
    """State 8"""
    Quit()
    """State 9"""
    Quit()
    """State 10"""
    Quit()
    """State 11"""
    Quit()
    """State 12"""
    Quit()

def t000001000_x12(goods11=1000, goods12=_, goods13=_):
    """State 0,1"""
    if (not DoesPlayerHaveItem(3, goods11 + goods13 + goods12 * 50 + 0 * 2) and not DoesPlayerHaveItem(3,
        goods11 + goods13 + goods12 * 50 + 1 * 2) and not DoesPlayerHaveItem(3, goods11 + goods13
        + goods12 * 50 + 2 * 2) and not DoesPlayerHaveItem(3, goods11 + goods13 + goods12 * 50 + 3
        * 2) and not DoesPlayerHaveItem(3, goods11 + goods13 + goods12 * 50 + 4 * 2) and not DoesPlayerHaveItem(3,
        goods11 + goods13 + goods12 * 50 + 5 * 2) and not DoesPlayerHaveItem(3, goods11 + goods13
        + goods12 * 50 + 6 * 2) and not DoesPlayerHaveItem(3, goods11 + goods13 + goods12 * 50 + 7
        * 2)):
        """State 2,3"""
        return 0
    else:
        """State 4"""
        return 1

def t000001000_x13():
    """State 0,1"""
    if DoesPlayerHaveSpEffect(8990):
        """State 2"""
        GiveSpEffectToPlayer(8998)
        """State 3"""
        SetEventFlag(100210, 0)
        SetEventFlag(100200, 0)
    else:
        pass
    """State 4"""
    return 0

def t000001000_x14(text1=_, flag5=_, mode3=1):
    """State 0,5"""
    assert t000001000_x2() and CheckSpecificPersonTalkHasEnded(0)
    """State 1"""
    TalkToPlayer(text1, -1, -1, 0)
    assert CheckSpecificPersonTalkHasEnded(0)
    """State 4"""
    if mode3 == 0:
        pass
    else:
        """State 3"""
        ReportConversationEndToHavokBehavior()
    """State 2"""
    SetEventFlag(flag5, 1)
    """State 6"""
    return 0

def t000001000_x15(goods9=1000):
    """State 0,4,10"""
    # goods:1000:Flask of Crimson Tears
    # goods:1001:Flask of Crimson Tears
    # goods:1002:Flask of Crimson Tears +1
    # goods:1003:Flask of Crimson Tears +1
    # goods:1004:Flask of Crimson Tears +2
    # goods:1005:Flask of Crimson Tears +2
    # goods:1006:Flask of Crimson Tears +3
    # goods:1007:Flask of Crimson Tears +3
    # goods:1008:Flask of Crimson Tears +4
    # goods:1009:Flask of Crimson Tears +4
    # goods:1010:Flask of Crimson Tears +5
    # goods:1011:Flask of Crimson Tears +5
    # goods:1012:Flask of Crimson Tears +6
    # goods:1013:Flask of Crimson Tears +6
    # goods:1014:Flask of Crimson Tears +7
    # goods:1015:Flask of Crimson Tears +7
    # goods:1016:Flask of Crimson Tears +8
    # goods:1017:Flask of Crimson Tears +8
    # goods:1018:Flask of Crimson Tears +9
    # goods:1019:Flask of Crimson Tears +9
    # goods:1020:Flask of Crimson Tears +10
    # goods:1021:Flask of Crimson Tears +10
    # goods:1022:Flask of Crimson Tears +11
    # goods:1023:Flask of Crimson Tears +11
    # goods:1024:Flask of Crimson Tears +12
    # goods:1025:Flask of Crimson Tears +12
    call = t000001000_x17(goods7=goods9, goods10=0, z44=1)
    if call.Get() == 0:
        """State 2,8"""
        # action:13040150:"No Flask of Crimson Tears in inventory"
        assert t000001000_x4(action6=13040150)
    elif call.Done():
        """State 1,7,12"""
        # goods:1050:Flask of Cerulean Tears
        # goods:1051:Flask of Cerulean Tears
        # goods:1052:Flask of Cerulean Tears +1
        # goods:1053:Flask of Cerulean Tears +1
        # goods:1054:Flask of Cerulean Tears +2
        # goods:1055:Flask of Cerulean Tears +2
        # goods:1056:Flask of Cerulean Tears +3
        # goods:1057:Flask of Cerulean Tears +3
        # goods:1058:Flask of Cerulean Tears +4
        # goods:1059:Flask of Cerulean Tears +4
        # goods:1060:Flask of Cerulean Tears +5
        # goods:1061:Flask of Cerulean Tears +5
        # goods:1062:Flask of Cerulean Tears +6
        # goods:1063:Flask of Cerulean Tears +6
        # goods:1064:Flask of Cerulean Tears +7
        # goods:1065:Flask of Cerulean Tears +7
        # goods:1066:Flask of Cerulean Tears +8
        # goods:1067:Flask of Cerulean Tears +8
        # goods:1068:Flask of Cerulean Tears +9
        # goods:1069:Flask of Cerulean Tears +9
        # goods:1070:Flask of Cerulean Tears +10
        # goods:1071:Flask of Cerulean Tears +10
        # goods:1072:Flask of Cerulean Tears +11
        # goods:1073:Flask of Cerulean Tears +11
        # goods:1074:Flask of Cerulean Tears +12
        # goods:1075:Flask of Cerulean Tears +12
        call = t000001000_x17(goods7=goods9, goods10=1, z44=1)
        if call.Get() == 0:
            """State 6,11"""
            # action:13040160:"No Flask of Cerulean Tears in inventory"
            assert t000001000_x4(action6=13040160)
        elif call.Done():
            """State 5,3"""
            OpenEstusAllotMenu()
            assert not (CheckSpecificPersonMenuIsOpen(14, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
            """State 9"""
            assert t000001000_x16(goods9=goods9)
    """State 13"""
    return 0

def t000001000_x16(goods9=1000):
    """State 0,3"""
    # goods:1000:Flask of Crimson Tears
    # goods:1001:Flask of Crimson Tears
    # goods:1002:Flask of Crimson Tears +1
    # goods:1003:Flask of Crimson Tears +1
    # goods:1004:Flask of Crimson Tears +2
    # goods:1005:Flask of Crimson Tears +2
    # goods:1006:Flask of Crimson Tears +3
    # goods:1007:Flask of Crimson Tears +3
    # goods:1008:Flask of Crimson Tears +4
    # goods:1009:Flask of Crimson Tears +4
    # goods:1010:Flask of Crimson Tears +5
    # goods:1011:Flask of Crimson Tears +5
    # goods:1012:Flask of Crimson Tears +6
    # goods:1013:Flask of Crimson Tears +6
    # goods:1014:Flask of Crimson Tears +7
    # goods:1015:Flask of Crimson Tears +7
    # goods:1016:Flask of Crimson Tears +8
    # goods:1017:Flask of Crimson Tears +8
    # goods:1018:Flask of Crimson Tears +9
    # goods:1019:Flask of Crimson Tears +9
    # goods:1020:Flask of Crimson Tears +10
    # goods:1021:Flask of Crimson Tears +10
    # goods:1022:Flask of Crimson Tears +11
    # goods:1023:Flask of Crimson Tears +11
    # goods:1024:Flask of Crimson Tears +12
    # goods:1025:Flask of Crimson Tears +12
    call = t000001000_x17(goods7=goods9, goods10=0, z44=1)
    if call.Get() == 1:
        """State 4"""
        assert t000001000_x18(goods9=goods9, mode2=0, z43=GetWorkValue(1))
        """State 5"""
        assert t000001000_x18(goods9=goods9, mode2=1, z43=GetWorkValue(1))
    elif call.Done():
        """State 1"""
        pass
    """State 2"""
    SetWorkValue(1, 0)
    """State 6"""
    return 0

def t000001000_x17(goods7=1000, goods10=_, z44=1):
    """State 0,13"""
    SetWorkValue(z44, 0)
    if (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 0 * 2) or DoesPlayerHaveItem(3,
        goods7 + 1 + goods10 * 50 + 0 * 2)):
        """State 1"""
        SetWorkValue(z44, 0)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 1 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 1 * 2)):
        """State 2"""
        SetWorkValue(z44, 1)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 2 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 2 * 2)):
        """State 3"""
        SetWorkValue(z44, 2)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 3 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 3 * 2)):
        """State 4"""
        SetWorkValue(z44, 3)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 4 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 4 * 2)):
        """State 5"""
        SetWorkValue(z44, 4)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 5 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 5 * 2)):
        """State 6"""
        SetWorkValue(z44, 5)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 6 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 6 * 2)):
        """State 7"""
        SetWorkValue(z44, 6)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 7 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 7 * 2)):
        """State 8"""
        SetWorkValue(z44, 7)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 8 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 8 * 2)):
        """State 9"""
        SetWorkValue(z44, 8)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 9 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 9 * 2)):
        """State 10"""
        SetWorkValue(z44, 9)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 10 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 10 * 2)):
        """State 11"""
        SetWorkValue(z44, 10)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 11 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 11 * 2)):
        """State 14"""
        SetWorkValue(z44, 11)
    elif (DoesPlayerHaveItem(3, goods7 + 0 + goods10 * 50 + 12 * 2) or DoesPlayerHaveItem(3,
          goods7 + 1 + goods10 * 50 + 12 * 2)):
        """State 15"""
        SetWorkValue(z44, 12)
    else:
        """State 12"""
        SetWorkValue(z44, 13)
        """State 16"""
        return 0
    """State 17"""
    return 1

def t000001000_x18(goods9=1000, mode2=_, z43=_):
    """State 0,6"""
    if not GetEstusAllocation(mode2) < 0:
        """State 7,12"""
        if (DoesPlayerHaveItem(3, goods9 + 0 + mode2 * 50 + z43 * 2) or DoesPlayerHaveItem(3,
            goods9 + 1 + mode2 * 50 + z43 * 2)):
            """State 13,1"""
            if DoesPlayerHaveItem(3, goods9 + 0 + mode2 * 50 + z43 * 2):
                """State 2,4"""
                ReplaceTool(1000 + mode2 * 50 + z43 * 2 + 0, 1000 + mode2 * 50 + z43 * 2 + 1, 1)
            else:
                """State 3"""
                pass
            while True:
                """State 5"""
                if (not ComparePlayerInventoryNumber(3, 1000 + 1 + mode2 * 50 + z43 * 2, 4,
                    GetEstusAllocation(mode2), False)):
                    """State 9,11"""
                    PlayerEquipmentQuantityChange(3, 1000 + 1 + mode2 * 50 + z43 * 2, 1)
                else:
                    """State 10"""
                    break
        else:
            """State 14"""
            pass
    else:
        """State 8"""
        pass
    """State 15"""
    return 0

def t000001000_x19(goods7=1000):
    """State 0,3"""
    # goods:1000:Flask of Crimson Tears
    # goods:1001:Flask of Crimson Tears
    # goods:1002:Flask of Crimson Tears +1
    # goods:1003:Flask of Crimson Tears +1
    # goods:1004:Flask of Crimson Tears +2
    # goods:1005:Flask of Crimson Tears +2
    # goods:1006:Flask of Crimson Tears +3
    # goods:1007:Flask of Crimson Tears +3
    # goods:1008:Flask of Crimson Tears +4
    # goods:1009:Flask of Crimson Tears +4
    # goods:1010:Flask of Crimson Tears +5
    # goods:1011:Flask of Crimson Tears +5
    # goods:1012:Flask of Crimson Tears +6
    # goods:1013:Flask of Crimson Tears +6
    # goods:1014:Flask of Crimson Tears +7
    # goods:1015:Flask of Crimson Tears +7
    # goods:1016:Flask of Crimson Tears +8
    # goods:1017:Flask of Crimson Tears +8
    # goods:1018:Flask of Crimson Tears +9
    # goods:1019:Flask of Crimson Tears +9
    # goods:1020:Flask of Crimson Tears +10
    # goods:1021:Flask of Crimson Tears +10
    # goods:1022:Flask of Crimson Tears +11
    # goods:1023:Flask of Crimson Tears +11
    # goods:1024:Flask of Crimson Tears +12
    # goods:1025:Flask of Crimson Tears +12
    call = t000001000_x17(goods7=goods7, goods10=0, z44=1)
    if call.Get() == 1:
        """State 4"""
        assert t000001000_x20(goods7=goods7, z42=GetWorkValue(1))
        """State 2"""
        SetWorkValue(1, 0)
    elif call.Done():
        """State 1"""
        pass
    """State 5"""
    return 0

def t000001000_x20(goods7=1000, z42=_):
    """State 0,1"""
    ReplaceToolIf(DoesPlayerHaveItem(3, 1000 + 0 + 0 * 50 + z42 * 2) == 1, goods7 + 0 * 50 + z42 * 2 + 0,
                  goods7 + 0 * 50 + 0 + 2 * (GetTotalBonfireLevel() - 1), 1)
    """State 2"""
    ReplaceToolIf(DoesPlayerHaveItem(3, 1000 + 1 + 0 * 50 + z42 * 2) == 1, goods7 + 0 * 50 + z42 * 2 + 1,
                  goods7 + 0 * 50 + 1 + 2 * (GetTotalBonfireLevel() - 1), 1)
    """State 3"""
    ReplaceToolIf(DoesPlayerHaveItem(3, 1000 + 0 + 1 * 50 + z42 * 2) == 1, goods7 + 1 * 50 + z42 * 2 + 0,
                  goods7 + 1 * 50 + 0 + 2 * (GetTotalBonfireLevel() - 1), 1)
    """State 4"""
    ReplaceToolIf(DoesPlayerHaveItem(3, 1000 + 1 + 1 * 50 + z42 * 2) == 1, goods7 + 1 * 50 + z42 * 2 + 1,
                  goods7 + 1 * 50 + 1 + 2 * (GetTotalBonfireLevel() - 1), 1)
    """State 5"""
    return 0

def t000001000_x21(z31=1, z32=1, z33=2, z34=2, z35=3, z36=3, z37=4, z38=4, z39=5, z40=5, z41=1):
    """State 0"""
    if GetWorkValue(z41) == 0:
        """State 1"""
        SetWorkValue(z41, z31)
    elif GetWorkValue(z41) == 1:
        """State 2"""
        SetWorkValue(z41, z32)
    elif GetWorkValue(z41) == 2:
        """State 3"""
        SetWorkValue(z41, z33)
    elif GetWorkValue(z41) == 3:
        """State 4"""
        SetWorkValue(z41, z34)
    elif GetWorkValue(z41) == 4:
        """State 5"""
        SetWorkValue(z41, z35)
    elif GetWorkValue(z41) == 5:
        """State 6"""
        SetWorkValue(z41, z36)
    elif GetWorkValue(z41) == 6:
        """State 7"""
        SetWorkValue(z41, z37)
    elif GetWorkValue(z41) == 7:
        """State 8"""
        SetWorkValue(z41, z38)
    elif GetWorkValue(z41) == 8:
        """State 9"""
        SetWorkValue(z41, z39)
    elif GetWorkValue(z41) == 9:
        """State 10"""
        SetWorkValue(z41, z40)
    else:
        """State 11"""
        SetWorkValue(z41, 5)
    """State 12"""
    return 0

def t000001000_x22():
    """State 0"""
    if not GetEventFlag(9000):
        """State 3,1"""
        SetEventFlag(4652, 0)
        SetEventFlag(4653, 0)
        SetEventFlag(4654, 0)
        SetEventFlag(4655, 0)
        SetEventFlag(4656, 0)
        SetEventFlag(4657, 0)
        SetEventFlag(4651, 0)
    else:
        """State 2"""
        pass
    while True:
        """State 4"""
        if IsMultiplayerInProgress() and not GetEventFlag(2051) and not GetEventFlag(2052):
            """State 6"""
            call = t000001000_x25()
            assert not IsMultiplayerInProgress() or GetEventFlag(2051) or GetEventFlag(2052)
        elif GetEventFlag(1042369415):
            """State 7"""
            call = t000001000_x63()
            assert not GetEventFlag(1042369415)
        else:
            """State 5"""
            def WhilePaused():
                GiveSpEffectToPlayerIf(GetEventFlag(9000) == 1 and (GetWorkValue(0) == 0) == 1, 9607)
                GiveSpEffectToPlayerIf(GetEventFlag(9000) == 1 and (GetWorkValue(0) == 10) == 1, 9608)
                GiveSpEffectToPlayerIf(GetEventFlag(9000) == 1 and GetDistanceToPlayer() < 1.05, 9609)
                GiveSpEffectToPlayerIf(GetEventFlag(4698) == 1 and GetEventFlag(9001) == 1, 9606)
            assert t000001000_x23()
    """Unused"""
    """State 8"""
    return 0

def t000001000_x23():
    """State 0,1"""
    if CompareBonfireLevel(5, 0) or GetEventFlag(11102790):
        """State 2"""
        Label('L0')
        assert GetWhetherChrEventAnimHasEnded(10000)
    else:
        """State 3,32"""
        call = t000001000_x40()
        if call.Done():
            """State 7"""
            TurnCharacterToFaceEntity(-1, 10000, -1, -1)
            assert GetCurrentStateElapsedFrames() > 1 and GetWhetherChrEventAnimHasEnded(10000)
            """State 4"""
            OfferHumanity()
            assert CompareBonfireLevel(5, 0)
            """State 9,10"""
            UpdatePlayerRespawnPoint()
            Goto('L0')
        elif CompareBonfireLevel(5, 0) or GetEventFlag(11102790):
            pass
    """State 33"""
    call = t000001000_x40()
    if call.Done():
        """State 5"""
        ClearPlayerDamageInfo()
        """State 11"""
        GiveSpEffectToPlayer(202)
        """State 6"""
        SetTalkTime(1)
        """State 37"""
        assert t000001000_x67()
        """State 23"""
        SetEventFlag(4698, 0)
        SetEventFlagIf(DoesSelfHaveSpEffect(9680) == 1 and GetEventFlag(953) == 0, 4698, 1)
        SetEventFlagIf((GetEventFlagValue(955, 3) > 2) == 1 and DoesSelfHaveSpEffect(9681) == 1 and GetEventFlag(953) == 0,
                       4698, 1)
        """State 30"""
        assert t000001000_x32()
        """State 8"""
        TurnCharacterToFaceEntity(-1, 10000, -1, -1)
        assert GetCurrentStateElapsedFrames() > 1 and GetWhetherChrEventAnimHasEnded(10000)
        """State 12"""
        UpdatePlayerRespawnPoint()
        """State 40"""
        assert t000001000_x82()
        """State 19"""
        StartBonfireAnimLoop(1, 1, 1, 1, GetWorkValue(0), 0.5)
        """State 13"""
        FadeOutAndPassTime(0, 0, 0, 0, 0, 0, 0, 0.1, 0, 1.5, 0, 0.75, 0.5)
        """State 18"""
        SetEventFlag(9000, 1)
        SetEventFlag(9020, 1)
        ChangeCameraIf(GetEventFlag(11102790) == 0, 1001000)
        ChangeCameraIf(GetEventFlag(11102790) == 1, 1001001)
        if not GetEventFlag(4698):
            """State 36"""
            assert t000001000_x66()
        else:
            """State 35"""
            assert t000001000_x64()
        """State 17"""
        if not GetEventFlag(9001):
            """State 21"""
            pass
        else:
            """State 20"""
            assert not GetEventFlag(9001)
        """State 41"""
        call = t000001000_x84()
        if call.Get() == 0:
            """State 26"""
            pass
        elif call.Get() == 1:
            """State 27,29"""
            assert t000001000_x30()
        """State 15"""
        if not GetEventFlag(4653):
            """State 22,39"""
            Label('L1')
            assert t000001000_x68()
            """State 31"""
            call = t000001000_x31()
            def WhilePaused():
                GiveSpEffectToPlayerIf(GetEventFlag(4651) == 1, 9620)
            def ExitPause():
                EndBonfireKindleAnimLoop(GetWorkValue(0))
            if call.Done():
                pass
            elif ((((GetDistanceToPlayer() > 3 and not GetEventFlag(11102790)) or GetDistanceToPlayer() > 7) and
                  GetCurrentStateElapsedFrames() > 1) or (CompareBonfireState(0) and GetCurrentStateElapsedFrames()
                  > 1) or (HasPlayerBeenAttacked() and GetCurrentStateElapsedFrames() > 1) or (IsMultiplayerInProgress()
                  and not GetEventFlag(2051) and not GetEventFlag(2052) and GetCurrentStateElapsedFrames() > 1)
                  or (GetEventFlag(1042369415) and GetCurrentStateElapsedFrames() > 1) or (CompareBonfireLevel(0,
                  0) and not GetEventFlag(11102790) and GetCurrentStateElapsedFrames() > 1)):
                """State 28"""
                Label('L2')
                assert t000001000_x24()
        else:
            """State 16,34"""
            call = t000001000_x50()
            if call.Done():
                Goto('L1')
            elif ((GetEventFlag(1042369415) and GetCurrentStateElapsedFrames() > 1) or (IsMultiplayerInProgress()
                  and GetCurrentStateElapsedFrames() > 1) or (HasPlayerBeenAttacked() and GetCurrentStateElapsedFrames()
                  > 1) or (((GetDistanceToPlayer() > 3 and not GetEventFlag(11102790)) or GetDistanceToPlayer()
                  > 7) and GetCurrentStateElapsedFrames() > 1) or (CompareBonfireState(0) and GetCurrentStateElapsedFrames()
                  > 1)):
                """State 24"""
                def ExitPause():
                    EndBonfireKindleAnimLoop(GetWorkValue(0))
                Goto('L2')
        """State 38"""
        assert t000001000_x67()
        """State 14"""
        SetEventFlag(9000, 0)
        SetEventFlag(9020, 0)
        ChangeCamera(-1)
        SetCanOpenMap(False)
        assert GetCurrentStateElapsedFrames() > 1
        """State 25"""
        if not IsMultiplayerInProgress() and not GetEventFlag(1042369415):
            Goto('L0')
        else:
            pass
    elif (GetEventFlag(1042369415) or (CompareBonfireLevel(0, 0) and not GetEventFlag(11102790))
          or (IsMultiplayerInProgress() and not GetEventFlag(2051) and not GetEventFlag(2052))):
        pass
    """State 42"""
    return 0

def t000001000_x24():
    """State 0,1"""
    assert t000001000_x1()
    """State 2"""
    return 0

def t000001000_x25():
    """State 0"""
    while True:
        """State 1"""
        call = t000001000_x26()
        assert IsClientPlayer()
        """State 2"""
        call = t000001000_x27()
        assert not IsClientPlayer()
    """Unused"""
    """State 3"""
    return 0

def t000001000_x26():
    """State 0,6"""
    call = t000001000_x1()
    if call.Done() and CompareBonfireLevel(5, 0):
        pass
    elif call.Done():
        """State 2,7"""
        # actionbutton:6100:"Touch grace"
        call = t000001000_x3(actionbutton1=6100, flag8=6001, flag9=6000)
        if call.Done():
            """State 4"""
            TurnCharacterToFaceEntity(-1, 10000, -1, -1)
            assert GetCurrentStateElapsedFrames() > 1 and GetWhetherChrEventAnimHasEnded(10000)
            """State 3"""
            OfferHumanity()
            """State 5"""
            UpdatePlayerRespawnPoint()
            assert CompareBonfireLevel(5, 0)
        elif CompareBonfireLevel(5, 0):
            pass
    """State 1"""
    Quit()
    """Unused"""
    """State 8"""
    return 0

def t000001000_x27():
    """State 0,1"""
    assert t000001000_x1()
    """State 2"""
    return 0

def t000001000_x28():
    """State 0,1"""
    if not GetEventFlag(4651):
        """State 3"""
        if GetEventFlag(4698):
            """State 5,10"""
            assert t000001000_x35(z26=20006, val4=0.5, z27=1, z28=2, z29=60)
        elif GetEventFlag(108):
            """State 9,13"""
            assert t000001000_x35(z26=20000, val4=3.5, z27=1, z28=2, z29=60)
        else:
            """State 4,6"""
            # eventflag:400001:lot:100010:Rold Medallion
            if not GetEventFlag(400001):
                """State 7,11"""
                assert t000001000_x35(z26=20000, val4=3.5, z27=1, z28=2, z29=60)
            else:
                """State 8,12"""
                assert t000001000_x35(z26=20001, val4=3.5, z27=1, z28=2, z29=60)
    else:
        """State 2"""
        pass
    """State 14"""
    return 0

def t000001000_x29(z30=_):
    """State 0,1"""
    RemoveDynamicCharacter(z30, 1.4)
    """State 2"""
    SetEventFlag(4651, 0)
    SetEventFlag(4652, 0)
    SetEventFlag(4653, 0)
    SetEventFlag(4654, 0)
    SetEventFlag(4655, 0)
    SetEventFlag(4656, 0)
    SetEventFlag(4657, 0)
    """State 3"""
    return 0

def t000001000_x30():
    """State 0"""
    if GetEventFlag(11102790):
        """State 3"""
        pass
    elif GetEventFlag(110):
        """State 1"""
        pass
    elif not GetEventFlag(953) or GetEventFlag(4698):
        """State 4"""
        assert t000001000_x59()
    elif not GetEventFlag(4680):
        """State 2"""
        pass
    elif GetEventFlag(108):
        """State 7"""
        assert t000001000_x62()
    # eventflag:400001:lot:100010:Rold Medallion
    elif GetEventFlag(11009260) and not GetEventFlag(400001):
        """State 6"""
        assert t000001000_x61()
    else:
        """State 5"""
        assert t000001000_x60()
    """State 8"""
    return 0

def t000001000_x31():
    """State 0,10"""
    assert GetCurrentStateElapsedTime() > 0.1 or not GetEventFlag(4651)
    """State 11"""
    assert not GetEventFlag(9001)
    """State 27"""
    # goods:1001:Flask of Crimson Tears
    # goods:1000:Flask of Crimson Tears
    # goods:1003:Flask of Crimson Tears +1
    # goods:1002:Flask of Crimson Tears +1
    # goods:1005:Flask of Crimson Tears +2
    # goods:1004:Flask of Crimson Tears +2
    # goods:1007:Flask of Crimson Tears +3
    # goods:1006:Flask of Crimson Tears +3
    # goods:1009:Flask of Crimson Tears +4
    # goods:1008:Flask of Crimson Tears +4
    # goods:1011:Flask of Crimson Tears +5
    # goods:1010:Flask of Crimson Tears +5
    # goods:1013:Flask of Crimson Tears +6
    # goods:1012:Flask of Crimson Tears +6
    # goods:1015:Flask of Crimson Tears +7
    # goods:1014:Flask of Crimson Tears +7
    # goods:1017:Flask of Crimson Tears +8
    # goods:1016:Flask of Crimson Tears +8
    # goods:1019:Flask of Crimson Tears +9
    # goods:1018:Flask of Crimson Tears +9
    # goods:1021:Flask of Crimson Tears +10
    # goods:1020:Flask of Crimson Tears +10
    # goods:1023:Flask of Crimson Tears +11
    # goods:1022:Flask of Crimson Tears +11
    # goods:1025:Flask of Crimson Tears +12
    # goods:1024:Flask of Crimson Tears +12
    # goods:1050:Flask of Cerulean Tears
    # goods:1051:Flask of Cerulean Tears
    # goods:1052:Flask of Cerulean Tears +1
    # goods:1053:Flask of Cerulean Tears +1
    # goods:1054:Flask of Cerulean Tears +2
    # goods:1055:Flask of Cerulean Tears +2
    # goods:1056:Flask of Cerulean Tears +3
    # goods:1057:Flask of Cerulean Tears +3
    # goods:1058:Flask of Cerulean Tears +4
    # goods:1059:Flask of Cerulean Tears +4
    # goods:1060:Flask of Cerulean Tears +5
    # goods:1061:Flask of Cerulean Tears +5
    # goods:1062:Flask of Cerulean Tears +6
    # goods:1063:Flask of Cerulean Tears +6
    # goods:1064:Flask of Cerulean Tears +7
    # goods:1065:Flask of Cerulean Tears +7
    # goods:1067:Flask of Cerulean Tears +8
    # goods:1066:Flask of Cerulean Tears +8
    # goods:1069:Flask of Cerulean Tears +9
    # goods:1068:Flask of Cerulean Tears +9
    assert t000001000_x8(goods11=1000)
    """State 5"""
    ClearPreviousMenuSelection()
    while True:
        """State 1"""
        Label('L0')
        ClearTalkListData()
        """State 2"""
        # action:15000420:"Pass time"
        AddTalkListDataIf(GetEventFlag(9411) == 0 or GetEventFlag(9412) == 1, 1, 15000420, -1)
        # action:15000540:"Level Up"
        AddTalkListDataIf(GetEventFlag(4680) == 1 or GetEventFlag(4699) == 1, 2, 15000540, -1)
        """State 38"""
        # action:15000371:"Flasks"
        assert t000001000_x71(z18=3, action3=15000371)
        """State 41"""
        # action:20010001:"Shadow Realm Blessing"
        # goods:2010000:Scadutree Fragment
        # goods:2010100:Revered Spirit Ash
        assert t000001000_x80(z1=50, action1=20010001, goods1=2010000, goods2=2010100)
        """State 17"""
        # action:15000390:"Memorize spell"
        AddTalkListData(4, 15000390, -1)
        # goods:250:Flask of Wondrous Physick
        # goods:251:Flask of Wondrous Physick
        # action:15000510:"Mix Wondrous Physick"
        AddTalkListDataIf(ComparePlayerInventoryNumber(3, 250, 2, 0, False) == 1 or ComparePlayerInventoryNumber(3, 251, 2, 0, False) == 1,
                          5, 15000510, -1)
        # action:15000395:"Sort chest"
        AddTalkListData(6, 15000395, -1)
        # action:15000520:"Great Runes"
        AddTalkListDataIf(PlayerHasTool(15) == 1, 7, 15000520, -1)
        # goods:8590:Whetstone Knife
        # action:15000530:"Ashes of War"
        AddTalkListDataIf(ComparePlayerInventoryNumber(3, 8590, 4, 1, False) == 1,
                          8, 15000530, -1)
        # goods:8163:Tailoring Tools
        # goods:8188:Golden Tailoring Tools
        # action:22230000:"Alter garments"
        AddTalkListDataIf(ComparePlayerInventoryNumber(3, 8163, 2, 0, False) == 1 or ComparePlayerInventoryNumber(3, 8188, 2, 0, False) == 1,
                          9, 22230000, -1)
        """State 44"""
        call = t000001000_x84()
        if call.Get() == 0:
            """State 25"""
            pass
        elif call.Get() == 1:
            """State 26,35"""
            assert t000001000_x52()
        """State 15"""
        # action:20000009:"Leave"
        AddTalkListData(99, 20000009, -1)
        """State 6"""
        SetEventFlag(4652, 0)
        SetEventFlag(4656, 0)
        SetEventFlag(4654, 0)
        SetEventFlag(4655, 0)
        """State 3"""
        SetCanOpenMap(True)
        ShowShopMessage(1)
        assert not (CheckSpecificPersonMenuIsOpen(1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        """State 8"""
        if GetTalkListEntryResult() == 1:
            """State 28"""
            SetCanOpenMap(False)
            ClearPreviousMenuSelection()
            def ExitPause():
                ClearPreviousMenuSelection()
            assert t000001000_x33()
        elif GetTalkListEntryResult() == 2:
            """State 18"""
            if not GetEventFlag(2051) and not GetEventFlag(2052):
                """State 19,29"""
                assert t000001000_x34()
            else:
                """State 20,39"""
                # action:20011032:"Cannot select while entering combat"
                assert t000001000_x4(action6=20011032)
        elif GetTalkListEntryResult() == 3:
            """State 34"""
            SetCanOpenMap(False)
            ClearPreviousMenuSelection()
            def ExitPause():
                ClearPreviousMenuSelection()
            assert t000001000_x47()
        elif GetTalkListEntryResult() == 4:
            """State 7"""
            OpenMagicEquip(-1, -1)
            assert not (CheckSpecificPersonMenuIsOpen(11, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        elif GetTalkListEntryResult() == 5:
            """State 12"""
            OpenPhysickMenu()
            assert not (CheckSpecificPersonMenuIsOpen(21, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        elif GetTalkListEntryResult() == 6:
            """State 9"""
            OpenRepository()
            assert not (CheckSpecificPersonMenuIsOpen(3, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        elif GetTalkListEntryResult() == 7:
            """State 13"""
            OpenGreatRuneEquipMenu()
            assert not (CheckSpecificPersonMenuIsOpen(24, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        elif GetTalkListEntryResult() == 8:
            """State 14"""
            OpenEquipmentChangeOfPurposeShop()
            assert not (CheckSpecificPersonMenuIsOpen(7, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        elif GetTalkListEntryResult() == 9:
            """State 16"""
            OpenTailoringShop(111000, 111399)
            assert not (CheckSpecificPersonMenuIsOpen(26, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        elif GetTalkListEntryResult() == 11:
            """State 30"""
            assert t000001000_x36(flag4=4655)
        elif GetTalkListEntryResult() == 12:
            """State 37"""
            assert t000001000_x36(flag4=4657)
        elif GetTalkListEntryResult() == 15:
            """State 36"""
            assert t000001000_x54()
        elif GetTalkListEntryResult() == 32:
            """State 32"""
            assert t000001000_x38()
        elif GetTalkListEntryResult() == 41 and GetEventFlag(120) and GetEventFlag(11102790):
            """State 21"""
            if not GetEventFlag(2051) and not GetEventFlag(2052):
                """State 22,33"""
                assert t000001000_x42()
            else:
                """State 23,40"""
                # action:20011031:"Cannot select while entering combat"
                assert t000001000_x4(action6=20011031)
        elif GetTalkListEntryResult() == 50:
            """State 24,42"""
            SetCanOpenMap(False)
            ClearPreviousMenuSelection()
            # goods:2010000:Scadutree Fragment
            # goods:2010100:Revered Spirit Ash
            def ExitPause():
                ClearPreviousMenuSelection()
            assert t000001000_x78(goods3=2010000, goods4=2010100)
        else:
            """State 4,43"""
            assert t000001000_x83()
            """State 45"""
            return 0
    """Unused"""
    """State 31"""
    assert t000001000_x37()
    Goto('L0')

def t000001000_x32():
    """State 0,1"""
    if GetEventFlag(1054532702):
        """State 2,4"""
        Label('L0')
        """State 3"""
        SetWorkValue(0, 0)
    elif GetEventFlag(4698):
        """State 8"""
        Goto('L0')
    elif GetEventFlag(11102790):
        """State 6,7"""
        SetWorkValue(0, 30)
    else:
        """State 5,9"""
        assert t000001000_x39()
    """State 10"""
    return 0

def t000001000_x33():
    """State 0,5"""
    CloseShopMessage()
    while True:
        """State 1"""
        ClearTalkListData()
        """State 2"""
        # action:15000430:"Until morning"
        AddTalkListData(1, 15000430, -1)
        # action:15000440:"Until noon"
        AddTalkListData(2, 15000440, -1)
        # action:15000450:"Until nightfall"
        AddTalkListData(3, 15000450, -1)
        # action:15000460:"Cancel"
        AddTalkListData(99, 15000460, -1)
        """State 3"""
        ShowShopMessage(1)
        assert not (CheckSpecificPersonMenuIsOpen(1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        """State 6"""
        if GetTalkListEntryResult() == 1:
            """State 7"""
            def ExitPause():
                HideClock(0.5)
            assert t000001000_x45(val1=0)
        elif GetTalkListEntryResult() == 2:
            """State 8"""
            def ExitPause():
                HideClock(0.5)
            assert t000001000_x45(val1=1)
        elif GetTalkListEntryResult() == 3:
            """State 9"""
            def ExitPause():
                HideClock(0.5)
            assert t000001000_x45(val1=2)
        else:
            """State 4,10"""
            assert t000001000_x72()
            """State 11"""
            return 0

def t000001000_x34():
    """State 0"""
    if not GetEventFlag(4651):
        """State 3,4"""
        OpenSoul()
        assert not (CheckSpecificPersonMenuIsOpen(10, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
    else:
        """State 2,1"""
        SetEventFlag(4652, 1)
        SetEventFlag(4656, 1)
        """State 5"""
        assert not GetEventFlag(4652)
        """State 6"""
        SetWorkValue(0, 0)
    """State 7"""
    return 0

def t000001000_x35(z26=_, val4=_, z27=1, z28=2, z29=60):
    """State 0,4"""
    assert not DoesPlayerHaveSpEffect(9600) and not DoesPlayerHaveSpEffect(9603)
    """State 1"""
    SpawnDynamicCharacter(2180, 21800000, 1, 3000, z26, z27, z28, z29)
    """State 2"""
    SetEventFlag(4651, 1)
    """State 3"""
    assert GetCurrentStateElapsedTime() > val4
    """State 5"""
    return 0

def t000001000_x36(flag4=_):
    """State 0"""
    if not GetEventFlag(4651):
        """State 1,8"""
        assert t000001000_x28()
    else:
        """State 4"""
        pass
    """State 3"""
    SetEventFlag(4652, 1)
    SetEventFlag(flag4, 1)
    """State 2"""
    assert (not GetEventFlag(4652) or (GetCurrentStateElapsedTime() > 5 and not DoesPlayerHaveSpEffect(9600) and
            not DoesPlayerHaveSpEffect(9603)))
    """State 5"""
    if not GetEventFlag(4680):
        """State 6,9"""
        assert t000001000_x29(z30=20010)
    else:
        """State 7"""
        pass
    """State 10"""
    return 0

def t000001000_x37():
    """State 0,1"""
    SetEventFlag(1054539200, 1)
    """State 4"""
    assert t000001000_x28()
    """State 2"""
    SetEventFlag(4652, 1)
    """State 3"""
    assert not GetEventFlag(4652)
    """State 5"""
    return 0

def t000001000_x38():
    """State 0,1"""
    SetEventFlag(1054539201, 1)
    """State 2"""
    SetEventFlag(1054539205, 1)
    """State 3"""
    assert GetCurrentStateElapsedTime() > 1.5
    """State 5"""
    SetEventFlag(9000, 0)
    SetEventFlag(9020, 0)
    """State 4"""
    ChangeCamera(-1)
    Quit()
    """Unused"""
    """State 6"""
    return 0

def t000001000_x39():
    """State 0,1"""
    if not CompareRNGValue(0, 0) != -1:
        """State 3,4"""
        ShuffleRNGSeed(100)
    else:
        """State 2"""
        pass
    """State 5"""
    SetRNGSeed()
    """State 6"""
    if CompareRNGValue(3, 69) == True:
        """State 7,8"""
        SetWorkValue(0, 0)
    elif CompareRNGValue(3, 99) == True:
        """State 9,10"""
        SetWorkValue(0, 10)
    else:
        """State 11,12"""
        SetWorkValue(0, 0)
    """State 13"""
    return 0

def t000001000_x40():
    """State 0"""
    while True:
        """State 1"""
        if GetEventFlag(1054532702):
            """State 2,7"""
            # actionbutton:6100:"Touch grace"
            # actionbutton:6101:"Rest at site of grace"
            call = t000001000_x65(actionbutton1=6100, actionbutton2=6101, val2=45, z21=-120)
            if call.Done():
                break
            elif not GetEventFlag(1054532702):
                pass
        elif GetEventFlag(11102790):
            """State 4,6"""
            # actionbutton:6102:"Rest at table of lost grace"
            # actionbutton:6103:"Rest at table of lost grace"
            call = t000001000_x44(actionbutton3=6102, actionbutton4=6103, val3=45)
            if call.Done():
                break
            elif not GetEventFlag(11102790):
                pass
        else:
            """State 3,5"""
            # actionbutton:6100:"Touch grace"
            # actionbutton:6101:"Rest at site of grace"
            call = t000001000_x41(actionbutton1=6100, actionbutton2=6101)
            if call.Done():
                break
            elif GetEventFlag(1054532702) or GetEventFlag(11102790):
                pass
    """State 8"""
    return 0

def t000001000_x41(actionbutton1=_, actionbutton2=_):
    """State 0,1"""
    if CompareBonfireLevel(0, 0):
        """State 2,4"""
        assert t000001000_x3(actionbutton1=actionbutton1, flag8=6001, flag9=6000)
    else:
        """State 3,5"""
        assert t000001000_x3(actionbutton1=actionbutton2, flag8=6001, flag9=6000)
    """State 6"""
    return 0

def t000001000_x42():
    """State 0,7"""
    # action:20011080:"Begin Journey <?nextLoopCount?>?"
    call = t000001000_x0(action7=20011080)
    if call.Get() == 0:
        """State 2,8"""
        # action:20011081:"If you begin Journey <?nextLoopCount?>, you will not be able\nto return to the present world of Journey <?loopCount?>.\nBegin Journey <?nextLoopCount?>?"
        call = t000001000_x0(action7=20011081)
        if call.Get() == 0:
            """State 3,5"""
            SetEventFlag(3001, 1)
            """State 6"""
            Quit()
        elif call.Done():
            """State 4"""
            pass
    elif call.Done():
        """State 1"""
        pass
    """State 9"""
    return 0

def t000001000_x43(z22=11, z23=12):
    """State 0,2"""
    SetEventFlag(1042379200, 0)
    SetEventFlag(1042379202, 0)
    SetEventFlag(1042379206, 0)
    SetEventFlag(1046389201, 0)
    SetEventFlag(1043349250, 0)
    SetEventFlag(1038509250, 0)
    SetEventFlag(1043539250, 0)
    SetEventFlag(11009255, 0)
    SetEventFlag(1043509200, 0)
    SetEventFlag(1054559200, 0)
    SetEventFlag(1036489250, 0)
    SetEventFlag(1039519250, 0)
    SetEventFlag(1037519200, 0)
    SetEventFlag(10009656, 0)
    SetEventFlag(11009270, 0)
    SetEventFlag(11009275, 0)
    SetEventFlag(1054539210, 0)
    SetEventFlag(35009350, 0)
    SetEventFlag(35009352, 0)
    SetEventFlag(1054539215, 0)
    """State 4"""
    SetEventFlag(1042379208, 0)
    SetEventFlag(11009265, 0)
    SetEventFlag(35009355, 0)
    SetEventFlag(35009358, 0)
    if not GetEventFlag(953):
        """State 1"""
        if not GetEventFlag(4699):
            pass
        else:
            """State 8"""
            assert t000001000_x46(z23=z22)
    elif GetEventFlag(11102790):
        """State 3"""
        pass
    # eventflag:400001:lot:100010:Rold Medallion
    elif GetEventFlag(11009260) and not GetEventFlag(400001):
        """State 5"""
        pass
    elif GetEventFlag(108):
        """State 7"""
        pass
    elif GetEventFlag(110):
        """State 6"""
        pass
    else:
        """State 9"""
        assert t000001000_x49(z22=z22, z23=z23)
    """State 10"""
    return 0

def t000001000_x44(actionbutton3=6102, actionbutton4=6103, val3=45):
    """State 0"""
    if GetRelativeAngleBetweenPlayerAndSelf() < val3:
        """State 1"""
        Label('L0')
        """State 3"""
        call = t000001000_x41(actionbutton1=actionbutton3, actionbutton2=actionbutton4)
        if call.Done():
            """State 4"""
            return 0
        elif not GetRelativeAngleBetweenPlayerAndSelf() < val3:
            pass
    else:
        pass
    """State 2"""
    assert GetRelativeAngleBetweenPlayerAndSelf() < val3
    Goto('L0')

def t000001000_x45(val1=_):
    """State 0,8"""
    assert t000001000_x13()
    """State 10"""
    assert t000001000_x74(val1=val1)
    """State 4"""
    if val1 == 0:
        """State 1"""
        ShowClock(2)
        SetCurrentTime(0, 0, 0, 0, GetMorningHours(), GetMorningMinutes(), GetMorningSeconds(), 2.5, 0.75, 2, 0, 0.75, 0.5)
    elif val1 == 1:
        """State 2"""
        ShowClock(2)
        SetCurrentTime(0, 0, 0, 0, GetNoonHours(), GetNoonMinutes(), GetNoonSeconds(), 2.5, 0.75, 2, 0, 0.75, 0.5)
    elif val1 == 2:
        """State 3"""
        ShowClock(2)
        SetCurrentTime(0, 0, 0, 0, GetNightHours(), GetNightMinutes(), GetNightSeconds(), 2.5, 0.75, 2, 0, 0.75, 0.5)
    """State 5"""
    assert GetCurrentStateElapsedTime() > 0.8
    """State 9"""
    assert t000001000_x29(z30=0)
    """State 6"""
    assert IsTimePassFadeOutInProgress() == False
    """State 7"""
    assert GetCurrentStateElapsedTime() > 2.5
    """State 11"""
    return 0

def t000001000_x46(z23=_):
    """State 0,1"""
    # action:99990301:"Speak with Merina"
    AddTalkListData(z23, 99990301, -1)
    """State 2"""
    return 0

def t000001000_x47():
    """State 0,13"""
    assert t000001000_x48()
    """State 5"""
    CloseShopMessage()
    while True:
        """State 1"""
        ClearTalkListData()
        """State 14"""
        # action:15000370:"Add charge to flask"
        assert t000001000_x69(z20=1, action5=15000370)
        """State 15"""
        # action:15000380:"Increase amount replenished by flasks"
        assert t000001000_x70(z19=2, action4=15000380)
        """State 2"""
        # action:15000385:"Allocate flask charges"
        AddTalkListData(3, 15000385, -1)
        # action:15000372:"Cancel"
        AddTalkListData(99, 15000372, -1)
        """State 3"""
        ShowShopMessage(1)
        assert not (CheckSpecificPersonMenuIsOpen(1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        """State 6"""
        if GetTalkListEntryResult() == 1:
            """State 10"""
            # goods:1000:Flask of Crimson Tears
            # goods:1001:Flask of Crimson Tears
            # goods:1002:Flask of Crimson Tears +1
            # goods:1003:Flask of Crimson Tears +1
            # goods:1004:Flask of Crimson Tears +2
            # goods:1005:Flask of Crimson Tears +2
            # goods:1006:Flask of Crimson Tears +3
            # goods:1007:Flask of Crimson Tears +3
            # goods:1008:Flask of Crimson Tears +4
            # goods:1009:Flask of Crimson Tears +4
            # goods:1010:Flask of Crimson Tears +5
            # goods:1011:Flask of Crimson Tears +5
            # goods:1012:Flask of Crimson Tears +6
            # goods:1013:Flask of Crimson Tears +6
            # goods:1014:Flask of Crimson Tears +7
            # goods:1015:Flask of Crimson Tears +7
            # goods:1016:Flask of Crimson Tears +8
            # goods:1017:Flask of Crimson Tears +8
            # goods:1018:Flask of Crimson Tears +9
            # goods:1019:Flask of Crimson Tears +9
            # goods:1020:Flask of Crimson Tears +10
            # goods:1021:Flask of Crimson Tears +10
            # goods:1022:Flask of Crimson Tears +11
            # goods:1023:Flask of Crimson Tears +11
            # goods:1024:Flask of Crimson Tears +12
            # goods:1025:Flask of Crimson Tears +12
            # goods:10010:Golden Seed
            assert t000001000_x7(goods5=1000, goods6=10010)
        elif GetTalkListEntryResult() == 2:
            """State 7"""
            if not GetEventFlag(2051) and not GetEventFlag(2052):
                """State 8,11"""
                # goods:1000:Flask of Crimson Tears
                # goods:1001:Flask of Crimson Tears
                # goods:1002:Flask of Crimson Tears +1
                # goods:1003:Flask of Crimson Tears +1
                # goods:1004:Flask of Crimson Tears +2
                # goods:1005:Flask of Crimson Tears +2
                # goods:1006:Flask of Crimson Tears +3
                # goods:1007:Flask of Crimson Tears +3
                # goods:1008:Flask of Crimson Tears +4
                # goods:1009:Flask of Crimson Tears +4
                # goods:1010:Flask of Crimson Tears +5
                # goods:1011:Flask of Crimson Tears +5
                # goods:1012:Flask of Crimson Tears +6
                # goods:1013:Flask of Crimson Tears +6
                # goods:1014:Flask of Crimson Tears +7
                # goods:1015:Flask of Crimson Tears +7
                # goods:1016:Flask of Crimson Tears +8
                # goods:1017:Flask of Crimson Tears +8
                # goods:1018:Flask of Crimson Tears +9
                # goods:1019:Flask of Crimson Tears +9
                # goods:1020:Flask of Crimson Tears +10
                # goods:1021:Flask of Crimson Tears +10
                # goods:1022:Flask of Crimson Tears +11
                # goods:1023:Flask of Crimson Tears +11
                # goods:1024:Flask of Crimson Tears +12
                # goods:1025:Flask of Crimson Tears +12
                # goods:10020:Sacred Tear
                assert t000001000_x6(goods7=1000, goods8=10020)
            else:
                """State 9,16"""
                # action:20011030:"Cannot select while entering combat"
                assert t000001000_x4(action6=20011030)
        elif GetTalkListEntryResult() == 3:
            """State 12"""
            # goods:1000:Flask of Crimson Tears
            # goods:1050:Flask of Cerulean Tears
            # goods:1001:Flask of Crimson Tears
            # goods:1051:Flask of Cerulean Tears
            # goods:1002:Flask of Crimson Tears +1
            # goods:1052:Flask of Cerulean Tears +1
            # goods:1003:Flask of Crimson Tears +1
            # goods:1053:Flask of Cerulean Tears +1
            # goods:1004:Flask of Crimson Tears +2
            # goods:1054:Flask of Cerulean Tears +2
            # goods:1005:Flask of Crimson Tears +2
            # goods:1055:Flask of Cerulean Tears +2
            # goods:1006:Flask of Crimson Tears +3
            # goods:1056:Flask of Cerulean Tears +3
            # goods:1007:Flask of Crimson Tears +3
            # goods:1057:Flask of Cerulean Tears +3
            # goods:1008:Flask of Crimson Tears +4
            # goods:1058:Flask of Cerulean Tears +4
            # goods:1009:Flask of Crimson Tears +4
            # goods:1059:Flask of Cerulean Tears +4
            # goods:1010:Flask of Crimson Tears +5
            # goods:1060:Flask of Cerulean Tears +5
            # goods:1011:Flask of Crimson Tears +5
            # goods:1061:Flask of Cerulean Tears +5
            # goods:1012:Flask of Crimson Tears +6
            # goods:1062:Flask of Cerulean Tears +6
            # goods:1013:Flask of Crimson Tears +6
            # goods:1063:Flask of Cerulean Tears +6
            # goods:1014:Flask of Crimson Tears +7
            # goods:1064:Flask of Cerulean Tears +7
            # goods:1015:Flask of Crimson Tears +7
            # goods:1065:Flask of Cerulean Tears +7
            # goods:1016:Flask of Crimson Tears +8
            # goods:1066:Flask of Cerulean Tears +8
            # goods:1017:Flask of Crimson Tears +8
            # goods:1067:Flask of Cerulean Tears +8
            # goods:1018:Flask of Crimson Tears +9
            # goods:1068:Flask of Cerulean Tears +9
            # goods:1019:Flask of Crimson Tears +9
            # goods:1069:Flask of Cerulean Tears +9
            # goods:1020:Flask of Crimson Tears +10
            # goods:1070:Flask of Cerulean Tears +10
            # goods:1021:Flask of Crimson Tears +10
            # goods:1071:Flask of Cerulean Tears +10
            # goods:1022:Flask of Crimson Tears +11
            # goods:1072:Flask of Cerulean Tears +11
            # goods:1023:Flask of Crimson Tears +11
            # goods:1073:Flask of Cerulean Tears +11
            # goods:1024:Flask of Crimson Tears +12
            # goods:1074:Flask of Cerulean Tears +12
            # goods:1025:Flask of Crimson Tears +12
            # goods:1075:Flask of Cerulean Tears +12
            assert t000001000_x15(goods9=1000)
        else:
            """State 4,17"""
            return 0

def t000001000_x48():
    """State 0"""
    if not GetEventFlag(720070) or not GetEventFlag(720080):
        """State 1,3"""
        SetEventFlag(720070, 1)
        SetEventFlag(720080, 1)
        """State 4"""
    else:
        """State 2"""
        pass
    """State 5"""
    return 0

def t000001000_x49(z22=11, z23=12):
    """State 0"""
    assert GetCurrentStateElapsedFrames() > 1
    """State 1"""
    assert t000001000_x57(z22=z22)
    """State 2"""
    assert t000001000_x58(z23=z23)
    """State 3"""
    return 0

def t000001000_x50():
    """State 0,9"""
    assert t000001000_x28()
    """State 7"""
    SetEventFlag(4652, 1)
    """State 4"""
    assert (not GetEventFlag(4652) or (GetCurrentStateElapsedTime() > 5 and not DoesPlayerHaveSpEffect(9600) and
            not DoesPlayerHaveSpEffect(9603)))
    """State 1"""
    if not GetEventFlag(4680):
        """State 2,8"""
        Label('L0')
        assert t000001000_x29(z30=20010) and GetCurrentStateElapsedTime() > 3
    elif GetEventFlag(108):
        """State 6"""
        Goto('L0')
    # eventflag:400001:lot:100010:Rold Medallion
    elif GetEventFlag(11009260) and not GetEventFlag(400001):
        """State 5"""
        Goto('L0')
    else:
        """State 3"""
        pass
    """State 10"""
    return 0

def t000001000_x51(z25=15):
    """State 0"""
    if not GetEventFlag(12019257):
        """State 1"""
        if not GetEventFlag(12019255):
            """State 5"""
            # action:21060900:"Talk to miniature Ranni"
            AddTalkListDataAlt(z25, 21060900, -1, 0, False)
        elif not GetEventFlag(12019256):
            """State 6"""
            # action:21060901:"Talk to miniature Ranni"
            AddTalkListDataAlt(z25, 21060901, -1, 0, False)
        else:
            """State 7"""
            # action:21060902:"Talk to miniature Ranni"
            AddTalkListDataAlt(z25, 21060902, -1, 0, False)
    elif not GetEventFlag(12019260):
        """State 2"""
        if not GetEventFlag(12012711):
            """State 8"""
            # action:21060903:"Talk to Ranni"
            AddTalkListDataAltIf(GetEventFlag(12019258) == 0, z25, 21060903, -1, 0, False)
            # action:21060903:"Talk to Ranni"
            AddTalkListDataAltIf(GetEventFlag(12019258) == 1, z25, 21060903, -1, 0, False)
        elif GetEventFlag(1045379208):
            """State 9"""
            # action:21060910:"Talk to Ranni"
            AddTalkListDataAlt(z25, 21060910, -1, 0, True)
        else:
            """State 13"""
            # action:21060911:"Talk to Ranni"
            AddTalkListDataAlt(z25, 21060911, -1, 0, True)
    elif not GetEventFlag(12019265):
        """State 3"""
        if not GetEventFlag(12012712) or not GetEventFlag(1045379208):
            """State 10"""
            # action:21060912:"Talk to Ranni"
            AddTalkListDataAltIf(GetEventFlag(12019261) == 0, z25, 21060912, -1, 0, False)
            # action:21060912:"Talk to Ranni"
            AddTalkListDataAltIf(GetEventFlag(12019261) == 1, z25, 21060912, -1, 0, False)
        else:
            """State 11"""
            # action:21060920:"Talk to Ranni"
            AddTalkListDataAlt(z25, 21060920, -1, 0, True)
    else:
        """State 4,12"""
        # action:21060921:"Talk to Ranni"
        AddTalkListDataAltIf(GetEventFlag(12019266) == 0, z25, 21060921, -1, 0, True)
        # action:21060921:"Talk to Ranni"
        AddTalkListDataAltIf(GetEventFlag(12019266) == 1, z25, 21060921, -1, 0, False)
    """State 14"""
    return 0

def t000001000_x52():
    """State 0"""
    # eventflag:400394:lot:103940:Miniature Ranni
    if (GetEventFlag(400394) and not GetEventFlag(12019280) and (GetEventFlag(12012710) or GetEventFlag(12012711)
        or GetEventFlag(12012712))):
        """State 4"""
        assert t000001000_x51(z25=15)
    # eventflag:400394:lot:103940:Miniature Ranni
    elif GetEventFlag(400394) and GetEventFlag(1034509406) and GetEventFlag(12012713):
        """State 5"""
        assert t000001000_x53(z24=15)
    else:
        """State 3"""
        assert t000001000_x43(z22=11, z23=12)
    """State 1"""
    # action:20010101:"Listen to the sounds of flame"
    AddTalkListDataAltIf(GetEventFlag(1054532702) == 1 and GetEventFlag(108) == 1 and GetEventFlag(110) == 0, 32,
                         20010101, -1, 0, True)
    # action:20010080:"Begin Journey <?nextLoopCount?>"
    AddTalkListDataIf(GetEventFlag(120) == 1 and GetEventFlag(11102790) == 1, 41, 20010080, -1)
    """State 6"""
    return 0
    """Unused"""
    """State 2"""
    Quit()

def t000001000_x53(z24=15):
    """State 0"""
    if not GetEventFlag(12019275):
        """State 1"""
        # action:21060930:"Talk to miniature Ranni"
        AddTalkListDataAlt(z24, 21060930, -1, 0, False)
    else:
        """State 2"""
        # action:21060931:"Talk to Ranni"
        AddTalkListDataAltIf(GetEventFlag(12019276) == 0, z24, 21060931, -1, 0, False)
        # action:21060931:"Talk to Ranni"
        AddTalkListDataAltIf(GetEventFlag(12019276) == 1, z24, 21060931, -1, 0, False)
    """State 3"""
    return 0

def t000001000_x54():
    """State 0"""
    if not GetEventFlag(12012713):
        """State 1"""
        assert t000001000_x55()
    else:
        """State 2"""
        assert t000001000_x56()
    """State 3"""
    return 0

def t000001000_x55():
    """State 0"""
    if not GetEventFlag(12019257):
        """State 1"""
        if not GetEventFlag(12019255):
            """State 5"""
            # talk:10619000:"..."
            assert t000001000_x14(text1=10619000, flag5=12019255, mode3=1)
        elif not GetEventFlag(12019256):
            """State 6"""
            # talk:10619100:"..."
            assert t000001000_x14(text1=10619100, flag5=12019256, mode3=1)
        else:
            """State 7"""
            # talk:10619200:"..."
            # talk:10619201:"Oh? A dogged fellow, aren't we?"
            # talk:10619202:"Or is it merely thy habit, to talk to dolls?"
            # talk:10619203:"Fine...fine."
            # talk:10619204:"I hadn't expected any soul to recognise me in this guise."
            # talk:10619205:"But now the cat is out the bag, I cannot allow thee thy freedoms."
            # talk:10619206:"Perform for me a service, as recompense."
            # talk:10619207:"Eliminate the Baleful Shadows which prowl these lands."
            # talk:10619208:"The name of Ranni the Witch is already sullied by thee."
            # talk:10619209:"I will not brook disobedience in this matter."
            call = t000001000_x14(text1=10619200, flag5=12019257, mode3=1)
            assert call.Done() or call.Done()
    elif not GetEventFlag(12019260):
        """State 2"""
        if not GetEventFlag(12012711):
            """State 11"""
            # talk:10619300:"Perform for me a service, as recompense."
            # talk:10619301:"Eliminate the Baleful Shadows which prowl these lands."
            # talk:10619302:"The name of Ranni the Witch is already sullied by thee."
            # talk:10619303:"I will not brook disobedience in this matter."
            assert t000001000_x14(text1=10619300, flag5=12019258, mode3=1)
        elif GetEventFlag(1045379208):
            """State 8"""
            # talk:10620000:"Let us speak of the past, a while."
            # talk:10620001:"I was once an Empyrean."
            # talk:10620002:"Of the demigods, only I, Miquella, and Malenia could claim that title."
            # talk:10620003:"Each of us was chosen by our own Two Fingers, as a candidate to succeed Queen Marika,\nto become the new god of the coming age."
            # talk:10620004:"Which is when I received Blaidd. In the form of a vassal tailored for an Empyrean."
            # talk:10620005:"But I would not acquiesce to the Two Fingers."
            # talk:10620006:"I stole the Rune of Death, slew mine own Empyrean flesh, casting it away."
            # talk:10620007:"I would not be controlled by that thing."
            # talk:10620008:"The Two Fingers and I have been cursing each other ever since..."
            # talk:10620009:"And the Baleful Shadows...are their assassins."
            assert t000001000_x14(text1=10620000, flag5=12019260, mode3=1)
        else:
            """State 9"""
            # talk:10603000:"Let us speak of the past, a while."
            # talk:10603001:"I was once an Empyrean."
            # talk:10603002:"Of the demigods, only I, Miquella, and Malenia could claim that title."
            # talk:10603003:"Each of us was chosen by our own Two Fingers, as a candidate to succeed Queen Marika, to become the new god of the coming age."
            # talk:10603004:"But I would not acquiesce to the Two Fingers."
            # talk:10603005:"I stole the Rune of Death, slew mine own Empyrean flesh, casting it away."
            # talk:10603006:"I would not be controlled by that thing."
            # talk:10603007:"The Two Fingers and I have been cursing each other ever since..."
            # talk:10603008:"And the Baleful Shadows...are their assassins."
            assert t000001000_x14(text1=10603000, flag5=12019260, mode3=1)
    elif not GetEventFlag(12019265):
        """State 3"""
        if not GetEventFlag(12012712) or not GetEventFlag(1045379208):
            """State 12"""
            # talk:10620100:"I turned my back on the Two Fingers and we have each been cursing the other since."
            # talk:10620101:"The Baleful Shadows...are their assassins."
            assert t000001000_x14(text1=10620100, flag5=12019261, mode3=1)
        else:
            """State 10"""
            # talk:10621000:"Even when I turned my back upon the Two Fingers."
            # talk:10621001:"Blaidd remained my loyal ally."
            # talk:10621002:"Heh."
            # talk:10621003:"Though he was created a vassal for an Empyrean,"
            # talk:10621004:"He was a colossal failure, on the part of the Two Fingers."
            # talk:10621005:"Blaidd, and Iji both... Art willing to give too much to me."
            # talk:10621006:"Yet they both understand. What lieth beyond the dark path..."
            # talk:10621007:"That I must betray everything, and rid the world of what came before."
            # talk:10621008:"Ah, should I add thee to the list?"
            # talk:10621009:"Another one, kind of heart. As kind of heart as they."
            assert t000001000_x14(text1=10621000, flag5=12019265, mode3=1)
    else:
        """State 4,13"""
        # talk:10621100:"Ach, this form hath loosened my tongue."
        # talk:10621101:"I've let slip too much."
        # talk:10621102:"Forget what thou'st heard. Forget."
        assert t000001000_x14(text1=10621100, flag5=12019266, mode3=1)
    """State 14"""
    return 0

def t000001000_x56():
    """State 0"""
    if not GetEventFlag(12019275):
        """State 2"""
        # talk:10625000:"..."
        # talk:10625001:"I take it thou'st noticed? I shouldn't be surprised."
        # talk:10625002:"I thought I might expound a little further..."
        # talk:10625003:"Upon the order I envision."
        # talk:10625004:"Mine will be an order not of gold, but the stars and moon of the chill night."
        # talk:10625005:"I would keep them far from the earth beneath our feet."
        # talk:10625006:"As it is now, life, and souls, and order are bound tightly together, but I would have them at a great remove."
        # talk:10625007:"And have the certainties of sight, emotion, faith, and touch..."
        # talk:10625008:"All become impossibilities."
        # talk:10625009:"Which is why I would abandon this soil, with mine order."
        # talk:10625010:"Wouldst thou come to me, even now, my one and only Lord?"
        assert t000001000_x14(text1=10625000, flag5=12019275, mode3=1)
    else:
        """State 3"""
        # talk:10625100:"Mine will be an order not of gold, but the stars and moon of the chill night."
        # talk:10625101:"And I would abandon this soil, with mine Order."
        # talk:10625102:"Wouldst thou come to me, even now, my one and only Lord?"
        assert t000001000_x14(text1=10625100, flag5=12019276, mode3=1)
    """State 1"""
    SetEventFlag(1034509407, 1)
    """State 4"""
    return 0

def t000001000_x57(z22=11):
    """State 0,7"""
    if not GetEventFlag(4680):
        """State 4"""
        if not GetEventFlag(1042372700):
            """State 2"""
            # action:21000001:"Talk to Melina"
            AddTalkListDataAlt(z22, 21000001, -1, 0, True)
            SetEventFlag(1042379200, 1)
        elif GetEventFlag(4699):
            """State 31"""
            assert t000001000_x46(z23=z22)
        else:
            """State 5"""
            pass
    else:
        """State 6"""
        if (GetEventFlag(10009655) and not GetEventFlag(105) and not DoesPlayerHaveSpEffect(4270) and not DoesPlayerHaveSpEffect(4271)
            and not DoesPlayerHaveSpEffect(4272) and not DoesPlayerHaveSpEffect(4280) and not DoesPlayerHaveSpEffect(4282)
            and not DoesPlayerHaveSpEffect(4286)):
            """State 18"""
            # action:21000050:"Tell her you're off to Roundtable Hold"
            AddTalkListDataAlt(z22, 21000050, -1, 0, True)
            SetEventFlag(10009656, 1)
        elif GetEventFlag(1042372701) and not GetEventFlag(1042379203) and not GetEventFlag(10009655):
            """State 3"""
            # action:21000002:"Talk to Melina"
            AddTalkListDataAlt(z22, 21000002, -1, 0, True)
            SetEventFlag(1042379202, 1)
        elif GetEventFlag(1042372703):
            """State 28"""
            SetEventFlag(1042379208, 1)
            # action:21000004:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1042379209) == 0, z22, 21000004, -1, 0, True)
            # action:21000004:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1042379209) == 1, z22, 21000004, -1, 0, False)
        elif (not GetEventFlag(1042372702) and not GetEventFlag(1042379207) and GetEventFlag(1042379203) and not
              GetEventFlag(10009655)):
            """State 8"""
            # action:21000003:"Talk to Melina"
            AddTalkListDataAlt(z22, 21000003, -1, 0, True)
            SetEventFlag(1042379206, 1)
        elif GetEventFlag(1046382701) and not GetEventFlag(1046389202):
            """State 9"""
            SetEventFlag(1046389201, 1)
            # action:21000005:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1046389203) == 0 and GetEventFlag(1046382700) == 0, z22, 21000005,
                                 -1, 0, True)
            # action:21000005:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1046389203) == 1 and GetEventFlag(1046382700) == 0, z22, 21000005,
                                 -1, 0, False)
            # action:21000006:"Talk to Melina"
            AddTalkListDataIf(GetEventFlag(1046382700) == 1, z22, 21000006, -1)
        elif GetEventFlag(1043342700) and not GetEventFlag(1043349251):
            """State 10"""
            SetEventFlag(1043349250, 1)
            # action:21000007:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1043349252) == 0 and GetEventFlag(1046382700) == 0, z22, 21000007,
                                 -1, 0, True)
            # action:21000007:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1043349252) == 1 and GetEventFlag(1046382700) == 0, z22, 21000007,
                                 -1, 0, False)
            # action:21000008:"Talk to Melina"
            AddTalkListDataIf(GetEventFlag(1046382700) == 1, z22, 21000008, -1)
        elif GetEventFlag(1038502710) and not GetEventFlag(1038509251):
            """State 11"""
            SetEventFlag(1038509250, 1)
            # action:21000009:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1038509252) == 0 and GetEventFlag(1046382700) == 0, z22, 21000009,
                                 -1, 0, True)
            # action:21000009:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1038509252) == 1 and GetEventFlag(1046382700) == 0, z22, 21000009,
                                 -1, 0, False)
            # action:21000010:"Talk to Melina"
            AddTalkListDataIf(GetEventFlag(1046382700) == 1, z22, 21000010, -1)
        elif GetEventFlag(1043532710) and not GetEventFlag(1043539251):
            """State 12"""
            SetEventFlag(1043539250, 1)
            # action:21000011:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1043539252) == 0 and GetEventFlag(1046382700) == 0, z22, 21000011,
                                 -1, 0, True)
            # action:21000011:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1043539252) == 1 and GetEventFlag(1046382700) == 0, z22, 21000011,
                                 -1, 0, False)
            # action:21000012:"Talk to Melina"
            AddTalkListDataIf(GetEventFlag(1046382700) == 1, z22, 21000012, -1)
        elif GetEventFlag(11002740) and not GetEventFlag(11009256):
            """State 13"""
            SetEventFlag(11009255, 1)
            # action:21000013:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(11009257) == 0 and GetEventFlag(1046382700) == 0, z22, 21000013,
                                 -1, 0, True)
            # action:21000013:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(11009257) == 1 and GetEventFlag(1046382700) == 0, z22, 21000013,
                                 -1, 0, False)
            # action:21000014:"Talk to Melina"
            AddTalkListDataIf(GetEventFlag(1046382700) == 1, z22, 21000014, -1)
        elif GetEventFlag(1043502700) and not GetEventFlag(1043509201):
            """State 25"""
            SetEventFlag(1043509200, 1)
            # action:21000015:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1043509202) == 0 and GetEventFlag(1046382700) == 0, z22, 21000015,
                                 -1, 0, True)
            # action:21000015:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1043509202) == 1 and GetEventFlag(1046382700) == 0, z22, 21000015,
                                 -1, 0, False)
            # action:21000016:"Talk to Melina"
            AddTalkListDataIf(GetEventFlag(1046382700) == 1, z22, 21000016, -1)
        elif GetEventFlag(1054552700) and not GetEventFlag(1054559201):
            """State 14"""
            SetEventFlag(1054559200, 1)
            # action:21000017:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1054559202) == 0 and GetEventFlag(1046382700) == 0, z22, 21000017,
                                 -1, 0, True)
            # action:21000017:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1054559202) == 1 and GetEventFlag(1046382700) == 0, z22, 21000017,
                                 -1, 0, False)
            # action:21000018:"Talk to Melina"
            AddTalkListDataIf(GetEventFlag(1046382700) == 1, z22, 21000018, -1)
        # eventflag:400001:lot:100010:Rold Medallion
        elif (not GetEventFlag(1037519201) and not GetEventFlag(11009260) and not GetEventFlag(400001) and (GetEventFlag(1037512700)
              or GetEventFlag(1038512700) or GetEventFlag(1038502711) or GetEventFlag(1039512711) or GetEventFlag(1037522700))):
            """State 17"""
            # action:21000022:"Talk to Melina"
            AddTalkListDataAlt(z22, 21000022, -1, 0, True)
            SetEventFlag(1037519200, 1)
        elif GetEventFlag(1036482710) and GetEventFlag(1036489213) and GetEventFlag(3940) and not GetEventFlag(1036489251):
            """State 15"""
            # action:21000020:"Talk to Melina"
            AddTalkListDataAlt(z22, 21000020, -1, 0, True)
            SetEventFlag(1036489250, 1)
        elif (GetEventFlag(1039512710) and GetEventFlag(1039519209) and GetEventFlag(1036489210) and GetEventFlag(3940)
              and not GetEventFlag(1039519251)):
            """State 16"""
            SetEventFlag(1039519250, 1)
            # action:21000021:"Talk to Melina"
            AddTalkListDataAlt(z22, 21000021, -1, 0, True)
        elif GetEventFlag(11002745):
            """State 29"""
            # action:21000023:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(11009266) == 0, z22, 21000023, -1, 0, False)
            # action:21000023:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(11009266) == 1, z22, 21000023, -1, 0, False)
            SetEventFlag(11009265, 1)
        elif ((GetEventFlag(1054552701) or GetEventFlag(1052562700) or GetEventFlag(1052542700) or GetEventFlag(1051532700)
              or GetEventFlag(1052532710)) and not GetEventFlag(1054539211)):
            """State 21"""
            SetEventFlag(1054539210, 1)
            # action:21000026:"Talk to Melina"
            AddTalkListDataAlt(z22, 21000026, -1, 0, True)
        elif GetEventFlag(1054532702):
            """State 22"""
            SetEventFlag(1054539215, 1)
            # action:21000027:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1054539216) == 0, z22, 21000027, -1, 0, True)
            # action:21000027:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(1054539216) == 1, z22, 21000027, -1, 0, True)
        elif (GetEventFlag(35002730) or GetEventFlag(35002731)) and not GetEventFlag(35009351):
            """State 23"""
            SetEventFlag(35009350, 1)
            # action:21000028:"Talk to Melina"
            AddTalkListDataAlt(z22, 21000028, -1, 0, True)
        elif GetEventFlag(35002731) and not GetEventFlag(35009353):
            """State 24"""
            SetEventFlag(35009352, 1)
            # action:21000030:"Talk to Melina"
            AddTalkListDataAlt(z22, 21000030, -1, 0, True)
        elif GetEventFlag(35002732) and not GetEventFlag(35002733):
            """State 26"""
            # action:21000029:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(35009356) == 0 and GetEventFlag(35009357) == 0, z22, 21000029, -1,
                                 0, False)
            # action:21000029:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(35009356) == 1 or GetEventFlag(35009357) == 1, z22, 21000029, -1,
                                 0, False)
            SetEventFlag(35009355, 1)
        elif GetEventFlag(35002733):
            """State 27"""
            # action:21000031:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(35009359) == 0, z22, 21000031, -1, 0, False)
            # action:21000031:"Talk to Melina"
            AddTalkListDataAltIf(GetEventFlag(35009359) == 1, z22, 21000031, -1, 0, False)
            SetEventFlag(35009358, 1)
        elif GetEventFlag(11109387) and not GetEventFlag(11009271):
            """State 19"""
            SetEventFlag(11009270, 1)
            # action:21000024:"Talk to Melina"
            AddTalkListDataAlt(z22, 21000024, -1, 0, True)
        elif GetEventFlag(1049539207) and not GetEventFlag(11009276):
            """State 20"""
            SetEventFlag(11009275, 1)
            # action:21000025:"Talk to Melina"
            AddTalkListDataAlt(z22, 21000025, -1, 0, True)
        elif GetEventFlag(4699):
            """State 30"""
            assert t000001000_x46(z23=z22)
        else:
            """State 1"""
            pass
    """State 32"""
    return 0

def t000001000_x58(z23=12):
    """State 0,5"""
    if not GetEventFlag(4680):
        """State 2"""
        if GetEventFlag(4699):
            """State 7"""
            assert t000001000_x46(z23=z23)
        else:
            """State 3"""
            pass
    else:
        """State 4"""
        if GetEventFlag(4699):
            """State 6"""
            assert t000001000_x46(z23=z23)
        else:
            """State 1"""
            pass
    """State 8"""
    return 0

def t000001000_x59():
    """State 0"""
    if GetEventFlag(953):
        """State 3,1"""
        SetEventFlag(4653, 1)
    else:
        """State 2"""
        pass
    """State 4"""
    return 0

def t000001000_x60():
    """State 0"""
    if (GetEventFlag(10000851) and not GetEventFlag(10009655) and not DoesPlayerHaveSpEffect(4270) and not DoesPlayerHaveSpEffect(4271)
        and not DoesPlayerHaveSpEffect(4272) and not DoesPlayerHaveSpEffect(4280) and not DoesPlayerHaveSpEffect(4282)
        and not DoesPlayerHaveSpEffect(4286)):
        """State 2,3"""
        Label('L0')
        SetEventFlag(4653, 1)
    elif ((GetEventFlag(3062) or GetEventFlag(3063) or GetEventFlag(3064) or GetEventFlag(3065)) and not GetEventFlag(10009655)
          and not DoesPlayerHaveSpEffect(4270) and not DoesPlayerHaveSpEffect(4271) and not DoesPlayerHaveSpEffect(4272)
          and not DoesPlayerHaveSpEffect(4280) and not DoesPlayerHaveSpEffect(4282) and not DoesPlayerHaveSpEffect(4286)):
        """State 4"""
        Goto('L0')
    # eventflag:400001:lot:100010:Rold Medallion
    elif (not GetEventFlag(11009260) and not GetEventFlag(400001) and not GetEventFlag(9104) and (GetEventFlag(11002741)
          or GetEventFlag(11002742) or GetEventFlag(11002743) or GetEventFlag(11002744))):
        """State 5"""
        Goto('L0')
    # eventflag:400001:lot:100010:Rold Medallion
    elif GetEventFlag(9104) and not GetEventFlag(400001):
        """State 6"""
        Goto('L0')
    else:
        """State 1"""
        pass
    """State 7"""
    return 0

def t000001000_x61():
    """State 0"""
    # eventflag:400001:lot:100010:Rold Medallion
    if GetEventFlag(9104) and not GetEventFlag(400001):
        """State 2,1"""
        SetEventFlag(4653, 1)
    else:
        """State 3"""
        pass
    """State 4"""
    return 0

def t000001000_x62():
    """State 0"""
    if not GetEventFlag(35009360):
        """State 3,1"""
        SetEventFlag(4653, 1)
    else:
        """State 2"""
        pass
    """State 4"""
    return 0

def t000001000_x63():
    """State 0"""
    while True:
        """State 1"""
        if CompareBonfireLevel(0, 0):
            """State 2"""
            # actionbutton:6100:"Touch grace"
            assert t000001000_x5(actionbutton5=6100, flag6=6001, flag7=6000)
        else:
            """State 3"""
            # actionbutton:6101:"Rest at site of grace"
            assert t000001000_x3(actionbutton1=6101, flag8=6001, flag9=6000)
        """State 4"""
        # action:20011020:"Cannot rest at sites of grace right now"
        assert t000001000_x4(action6=20011020)
    """Unused"""
    """State 5"""
    return 0

def t000001000_x64():
    """State 0,2"""
    if GetCurrentStateElapsedTime() > 0.8:
        """State 3"""
        GiveSpEffectToPlayer(9606)
        def WhilePaused():
            GiveSpEffectToPlayer(9606)
        def ExitPause():
            GiveSpEffectToPlayer(9606)
        if IsTimePassFadeOutInProgress() == False:
            pass
        elif GetEventFlag(9001):
            """State 1"""
            Label('L0')
    elif GetEventFlag(9001):
        Goto('L0')
    """State 4"""
    return 0

def t000001000_x65(actionbutton1=6100, actionbutton2=6101, val2=45, z21=-120):
    """State 0"""
    if RelativeAngleBetweenTwoPlayersWithAxis(z21) < val2:
        """State 1"""
        Label('L0')
        """State 3"""
        call = t000001000_x41(actionbutton1=actionbutton1, actionbutton2=actionbutton2)
        if call.Done():
            """State 4"""
            return 0
        elif not RelativeAngleBetweenTwoPlayersWithAxis(z21) < val2:
            pass
    else:
        pass
    """State 2"""
    assert RelativeAngleBetweenTwoPlayersWithAxis(z21) < val2
    Goto('L0')

def t000001000_x66():
    """State 0,2"""
    if GetCurrentStateElapsedTime() > 0.8:
        """State 3"""
        GiveSpEffectToPlayer(9610)
        def WhilePaused():
            GiveSpEffectToPlayer(9610)
        def ExitPause():
            GiveSpEffectToPlayer(9610)
        if IsTimePassFadeOutInProgress() == False:
            pass
        elif GetEventFlag(9001):
            """State 1"""
            Label('L0')
    elif GetEventFlag(9001):
        Goto('L0')
    """State 4"""
    return 0

def t000001000_x67():
    """State 0"""
    # eventflag:400001:lot:100010:Rold Medallion
    if GetEventFlag(400001) and not GetEventFlag(108) and not GetEventFlag(11002745):
        """State 1,3"""
        assert t000001000_x29(z30=20011)
    else:
        """State 2,4"""
        assert t000001000_x29(z30=20010)
    """State 5"""
    return 0

def t000001000_x68():
    """State 0"""
    if GetEventFlag(1054532702):
        """State 1"""
        if GetEventFlag(110) and not GetEventFlag(1054532703) and not GetEventFlag(9116):
            """State 3,7"""
            SetEventFlag(9000, 0)
            SetEventFlag(9020, 0)
            """State 6"""
            ChangeCamera(-1)
            """State 5"""
            SetEventFlag(1054539206, 1)
            assert GetCurrentStateElapsedTime() > 15
            """State 8"""
            ChangeCameraIf(GetEventFlag(11102790) == 0, 1001000)
            SetEventFlag(9000, 1)
            SetEventFlag(9020, 1)
            SetEventFlag(1054539206, 0)
        else:
            """State 4"""
            pass
    else:
        """State 2"""
        pass
    """State 9"""
    return 0

def t000001000_x69(z20=1, action5=15000370):
    """State 0,5"""
    SetWorkValue(1, GetEstusAllocation(0) + GetEstusAllocation(1) + -4)
    """State 6"""
    assert t000001000_x21(z31=1, z32=1, z33=2, z34=2, z35=3, z36=3, z37=4, z38=4, z39=5, z40=5, z41=1)
    """State 3"""
    # goods:10010:Golden Seed
    if (ComparePlayerInventoryNumber(3, 10010, 4, GetWorkValue(1), False)
        and GetEstusAllocation(0) + GetEstusAllocation(1) < 13):
        """State 1"""
        # action:15000370:"Add charge to flask"
        AddTalkListDataAlt(z20, action5, -1, 0, True)
    else:
        """State 2"""
        # action:15000370:"Add charge to flask"
        AddTalkListDataAlt(z20, action5, -1, 0, False)
    """State 4"""
    SetWorkValue(1, 0)
    """State 7"""
    return 0

def t000001000_x70(z19=2, action4=15000380):
    """State 0,3"""
    # goods:10020:Sacred Tear
    if (ComparePlayerInventoryNumber(3, 10020, 4, 1, False) and GetTotalBonfireLevel()
        <= 13):
        """State 1"""
        # action:15000380:"Increase amount replenished by flasks"
        AddTalkListDataAlt(z19, action4, -1, 0, True)
    else:
        """State 2"""
        # action:15000380:"Increase amount replenished by flasks"
        AddTalkListDataAlt(z19, action4, -1, 0, False)
    """State 4"""
    return 0

def t000001000_x71(z18=3, action3=15000371):
    """State 0,4"""
    SetWorkValue(1, GetEstusAllocation(0) + GetEstusAllocation(1) + -4)
    """State 7"""
    assert t000001000_x21(z31=1, z32=1, z33=2, z34=2, z35=3, z36=3, z37=4, z38=4, z39=5, z40=5, z41=1)
    """State 3"""
    # goods:10010:Golden Seed
    if (ComparePlayerInventoryNumber(3, 10010, 1, GetWorkValue(1), False) or not
        GetEstusAllocation(0) + GetEstusAllocation(1) < 13):
        """State 2"""
        # goods:10020:Sacred Tear
        if (ComparePlayerInventoryNumber(3, 10020, 3, 0, False) or not GetTotalBonfireLevel()
            <= 13):
            """State 5"""
            # action:15000371:"Flasks"
            AddTalkListDataAlt(z18, action3, -1, 0, False)
        else:
            """State 1"""
            Label('L0')
            # action:15000371:"Flasks"
            AddTalkListDataAlt(z18, action3, -1, 0, True)
    else:
        Goto('L0')
    """State 6"""
    SetWorkValue(1, 0)
    """State 8"""
    return 0

def t000001000_x72():
    """State 0,1"""
    SetEventFlag(4820, 0)
    SetEventFlag(4821, 0)
    SetEventFlag(4822, 0)
    """State 2"""
    SetEventFlag(4825, 0)
    SetEventFlag(4826, 0)
    SetEventFlag(4827, 0)
    """State 3"""
    return 0

def t000001000_x73(flag1=_, flag2=_, flag3=_):
    """State 0,1"""
    SetEventFlag(flag1, 1)
    """State 2"""
    SetEventFlag(flag2, 0)
    SetEventFlag(flag3, 0)
    """State 3"""
    return 0

def t000001000_x74(val1=_):
    """State 0,1"""
    if val1 == 0:
        """State 2,18"""
        assert t000001000_x73(flag1=4825, flag2=4826, flag3=4827)
        """State 5"""
        if IsTimeOfDayInRange(6, 0, 0, 11, 59, 59):
            """State 6,21"""
            Label('L0')
            assert t000001000_x73(flag1=4822, flag2=4820, flag3=4821)
        elif IsTimeOfDayInRange(12, 0, 0, 19, 59, 59):
            """State 7,22"""
            Label('L1')
            assert t000001000_x73(flag1=4821, flag2=4820, flag3=4822)
        elif IsTimeOfDayInRange(20, 0, 0, 5, 59, 59):
            """State 8,23"""
            Label('L2')
            assert t000001000_x73(flag1=4820, flag2=4821, flag3=4822)
        else:
            """State 9"""
            Label('L3')
    elif val1 == 1:
        """State 3,19"""
        assert t000001000_x73(flag1=4826, flag2=4825, flag3=4827)
        """State 10"""
        if IsTimeOfDayInRange(6, 0, 0, 11, 59, 59):
            """State 11"""
            Goto('L2')
        elif IsTimeOfDayInRange(12, 0, 0, 19, 59, 59):
            """State 12"""
            Goto('L0')
        elif IsTimeOfDayInRange(20, 0, 0, 5, 59, 59):
            """State 13"""
            Goto('L1')
        else:
            Goto('L3')
    elif val1 == 2:
        """State 4,20"""
        assert t000001000_x73(flag1=4827, flag2=4825, flag3=4826)
        """State 14"""
        if IsTimeOfDayInRange(6, 0, 0, 11, 59, 59):
            """State 15"""
            Goto('L1')
        elif IsTimeOfDayInRange(12, 0, 0, 19, 59, 59):
            """State 16"""
            Goto('L2')
        elif IsTimeOfDayInRange(20, 0, 0, 5, 59, 59):
            """State 17"""
            Goto('L0')
        else:
            Goto('L3')
    else:
        Goto('L3')
    """State 24"""
    return 0

def t000001000_x75(goods3=2010000):
    """State 0,1"""
    if GetEventFlag(720300):
        """State 2"""
        pass
    else:
        """State 3,5"""
        SetEventFlag(720300, 1)
    """State 6,4"""
    if GetScadutreeLevel() <= 20:
        """State 7,21"""
        assert t000001000_x81(z3=1, z4=2, z5=3, z6=2)
        """State 18,9,11"""
        # goods:2010000:Scadutree Fragment
        if ComparePlayerInventoryNumber(3, goods3, 4, GetWorkValue(2), False):
            """State 12,13"""
            # goods:2010000:Scadutree Fragment
            PlayerEquipmentQuantityChange(3, goods3, GetWorkValue(2) * -1)
            """State 15"""
            SetScadutreeLevel(GetScadutreeLevel() + 1)
            """State 20"""
            # action:20011062:"Scadutree Blessing empowered"
            assert t000001000_x4(action6=20011062)
            """State 16"""
            SetWorkValue(2, 0)
        else:
            """State 14,19"""
            # action:20011060:"Not enough Scadutree Fragments"
            assert t000001000_x4(action6=20011060)
    else:
        """State 8,17"""
        # action:20011064:"Scadutree Blessing cannot be empowered any further"
        assert t000001000_x4(action6=20011064)
    """State 22"""
    return 0

def t000001000_x76(goods4=2010100):
    """State 0,1"""
    if GetEventFlag(720310):
        """State 2"""
        pass
    else:
        """State 3,4"""
        SetEventFlag(720310, 1)
    """State 5,6"""
    if GetReveredSpiritAshLevel() <= 10:
        """State 7,18"""
        assert t000001000_x77(z7=1, z8=1, z9=1, z10=2, z11=2, z12=3, z13=3, z14=3, z15=4, z16=5, z17=2, mode1=1)
        """State 19,9,11"""
        # goods:2010100:Revered Spirit Ash
        if ComparePlayerInventoryNumber(3, goods4, 4, GetWorkValue(2), False):
            """State 12,13"""
            # goods:2010100:Revered Spirit Ash
            PlayerEquipmentQuantityChange(3, goods4, GetWorkValue(2) * -1)
            """State 15"""
            SetReveredSpiritAshLevel(GetReveredSpiritAshLevel() + 1)
            """State 21"""
            # action:20011063:"Revered Spirit Ash Blessing empowered"
            assert t000001000_x4(action6=20011063)
            """State 16"""
            SetWorkValue(2, 0)
        else:
            """State 14,20"""
            # action:20011061:"Not enough Revered Spirit Ashes"
            assert t000001000_x4(action6=20011061)
    else:
        """State 8,17"""
        # action:20011065:"Revered Spirit Ash Blessing cannot be empowered any further"
        assert t000001000_x4(action6=20011065)
    """State 22"""
    return 0

def t000001000_x77(z7=1, z8=1, z9=1, z10=2, z11=2, z12=3, z13=3, z14=3, z15=4, z16=5, z17=2, mode1=_):
    """State 0,13"""
    SetWorkValue(z17, 0)
    """State 14"""
    if mode1 == 0:
        """State 15,16"""
        SetWorkValue(z17, GetScadutreeLevel())
    else:
        """State 17,18"""
        SetWorkValue(z17, GetReveredSpiritAshLevel())
    """State 19,1"""
    if GetWorkValue(z17) == 0:
        """State 2"""
        SetWorkValue(z17, z7)
    elif GetWorkValue(z17) == 1:
        """State 3"""
        SetWorkValue(z17, z8)
    elif GetWorkValue(z17) == 2:
        """State 4"""
        SetWorkValue(z17, z9)
    elif GetWorkValue(z17) == 3:
        """State 5"""
        SetWorkValue(z17, z10)
    elif GetWorkValue(z17) == 4:
        """State 6"""
        SetWorkValue(z17, z11)
    elif GetWorkValue(z17) == 5:
        """State 7"""
        SetWorkValue(z17, z12)
    elif GetWorkValue(z17) == 6:
        """State 8"""
        SetWorkValue(z17, z13)
    elif GetWorkValue(z17) == 7:
        """State 9"""
        SetWorkValue(z17, z14)
    elif GetWorkValue(z17) == 8:
        """State 10"""
        SetWorkValue(z17, z15)
    elif GetWorkValue(z17) == 9:
        """State 11"""
        SetWorkValue(z17, z16)
    else:
        """State 12"""
        SetWorkValue(z17, 999)
    """State 20"""
    return 0

def t000001000_x78(goods3=2010000, goods4=2010100):
    """State 0,2"""
    CloseShopMessage()
    while True:
        """State 1"""
        ClearTalkListData()
        """State 3,8"""
        # action:20010002:"Scadutree Blessing (<?dlcPlayerDopingLevel?>)"
        assert t000001000_x79(z2=1, action2=20010002, mode1=0, goods3=goods3)
        """State 9"""
        # action:20010003:"Revered Spirit Ash Blessing (<?dlcBuddyDopingLevel?>)"
        assert t000001000_x79(z2=2, action2=20010003, mode1=1, goods3=goods4)
        """State 4"""
        # action:20010004:"Cancel"
        AddTalkListData(99, 20010004, -1)
        """State 5"""
        ShowShopMessage(1)
        assert not (CheckSpecificPersonMenuIsOpen(1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        """State 6"""
        if GetTalkListEntryResult() == 1:
            """State 10"""
            assert t000001000_x75(goods3=goods3)
        elif GetTalkListEntryResult() == 2:
            """State 11"""
            assert t000001000_x76(goods4=goods4)
        else:
            """State 7,12"""
            return 0

def t000001000_x79(z2=_, action2=_, mode1=_, goods3=_):
    """State 0,4,5"""
    if mode1 == 0:
        """State 6,8"""
        if GetScadutreeLevel() <= 20:
            """State 9,17"""
            assert t000001000_x81(z3=1, z4=2, z5=3, z6=2)
            """State 1"""
            Label('L0')
            if (ComparePlayerInventoryNumber(3, goods3, 4, GetWorkValue(2),
                False)):
                """State 2,12"""
                AddTalkListDataAlt(z2, action2, -1, 0, True)
            else:
                """State 3,13"""
                Label('L1')
                AddTalkListDataAlt(z2, action2, -1, 0, False)
        else:
            """State 10"""
            Label('L2')
            Goto('L1')
    else:
        """State 7,11"""
        if GetReveredSpiritAshLevel() <= 10:
            """State 15,16"""
            assert t000001000_x77(z7=1, z8=1, z9=1, z10=2, z11=2, z12=3, z13=3, z14=3, z15=4, z16=5, z17=2, mode1=mode1)
            Goto('L0')
        else:
            Goto('L2')
    """State 14"""
    SetWorkValue(2, 0)
    """State 18"""
    return 0

def t000001000_x80(z1=50, action1=20010001, goods1=2010000, goods2=2010100):
    """State 0,1,2"""
    if GetEntityID() > 20000000 and GetEntityID() < 28999999:
        """State 3"""
        Label('L0')
        """State 7,16"""
        assert t000001000_x81(z3=1, z4=2, z5=3, z6=2)
        """State 8"""
        # goods:2010000:Scadutree Fragment
        if ComparePlayerInventoryNumber(3, goods1, 1, GetWorkValue(2), False):
            """State 9,15"""
            assert t000001000_x77(z7=1, z8=1, z9=1, z10=2, z11=2, z12=3, z13=3, z14=3, z15=4, z16=5, z17=2, mode1=1)
            """State 10"""
            # goods:2010100:Revered Spirit Ash
            if ComparePlayerInventoryNumber(3, goods2, 1, GetWorkValue(2), False):
                """State 12"""
                # action:20010001:"Shadow Realm Blessing"
                AddTalkListDataAlt(z1, action1, -1, 0, False)
            else:
                """State 13"""
                Label('L1')
                """State 11"""
                # action:20010001:"Shadow Realm Blessing"
                AddTalkListDataAlt(z1, action1, -1, 0, True)
        else:
            Goto('L1')
        """State 14"""
        SetWorkValue(2, 0)
    else:
        """State 4"""
        if GetEntityID() > 40000000 and GetEntityID() < 43999999:
            Goto('L0')
        else:
            """State 5"""
            if GetEntityID() > 2000000000 and GetEntityID() < 2099999999:
                Goto('L0')
            else:
                """State 6"""
                pass
    """State 17"""
    return 0

def t000001000_x81(z3=1, z4=2, z5=3, z6=2):
    """State 0,6"""
    SetWorkValue(z6, 0)
    """State 7,8"""
    SetWorkValue(z6, GetScadutreeLevel())
    """State 9,1"""
    if GetWorkValue(z6) <= 1:
        """State 2"""
        SetWorkValue(z6, z3)
    elif GetWorkValue(z6) <= 9:
        """State 3"""
        SetWorkValue(z6, z4)
    elif GetWorkValue(z6) <= 20:
        """State 4"""
        SetWorkValue(z6, z5)
    else:
        """State 5"""
        SetWorkValue(z6, 999)
    """State 10"""
    return 0

def t000001000_x82():
    """State 0,5"""
    SetEventFlag(4828, 0)
    SetEventFlag(4829, 0)
    SetEventFlag(4830, 0)
    """State 1"""
    if GetEntityID() > 2045420950 and GetEntityID() < 2045420950:
        """State 2,3"""
        SetEventFlag(4828, 1)
        """State 8"""
        SetEventFlag(4830, 1)
    elif GetEntityID() > 21010953 and GetEntityID() < 21010953:
        """State 6,7"""
        SetEventFlag(4829, 1)
    else:
        """State 4"""
        pass
    """State 9"""
    return 0

def t000001000_x83():
    """State 0,1"""
    if GetEntityID() > 2048420950 and GetEntityID() < 2048420950:
        """State 2,3"""
        SetEventFlag(2048422709, 1)
    elif GetEntityID() > 21010953 and GetEntityID() < 21010953:
        """State 4,6"""
        SetEventFlag(21012732, 1)
    elif GetEntityID() > 2049390950 and GetEntityID() < 2049390950:
        """State 7,8"""
        SetEventFlag(2049392710, 1)
    else:
        """State 5"""
        pass
    """State 9"""
    return 0

def t000001000_x84():
    """State 0,1"""
    if ((GetEntityID() > 20000000 and GetEntityID() < 28999999) or (GetEntityID() > 40000000 and GetEntityID()
        < 43999999) or (GetEntityID() > 2000000000 and GetEntityID() < 2099999999)):
        """State 2,4"""
        return 0
    else:
        """State 3,5"""
        return 1
