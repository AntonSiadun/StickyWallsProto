using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using System;
using AntonSiadun.StickyWallsProto.Domain.Movement;
using AntonSiadun.StickyWallsProto.Domain.Movement.JumpController;
using AntonSiadun.StickyWallsProto.Domain.Movement.Counters;

public class LongJumpTests
{
    private LongJump CreateLongJump()
    {
        var holder = new GameObject();
        return holder.AddComponent<LongJump>();
    }

    [Test]
    public void Initializtion_InitializeWithNullReferences_ThrowException()
    {
        var longJump = CreateLongJump();

        Assert.Throws<NullReferenceException>(() => longJump.Inittialize(null, null, null));
    }

    [Test]
    public void BaseJump_CharacterIsGrounded_JumpsCountDontChange()
    {
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();
        var count = 1;

        longJump.Inittialize(characterMock, counterMock, timerMock);
        counterMock.When(x => x.Reset()).Do( x => count--);
        characterMock.IsGrounded.Returns(true);
        longJump.BaseJump();

        Assert.AreEqual( 0, count);
    }

    [Test]
    public void BaseJump_CharacterIsntGroundedAndJumpCountMoreThan0_CharacterTurnBack()
    {
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();

        longJump.Inittialize(characterMock, counterMock, timerMock);
        characterMock.IsGrounded.Returns(false);
        counterMock.Current.Returns(1);
        longJump.BaseJump();

        characterMock.Received().TurnBack();
    }

    [Test]
    public void BaseJump_CharacterIsntGroundedAndJumpCountMoreThan0_DecrementCountOfJumps()
    {
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();
        var jumpsCount = 1;

        longJump.Inittialize(characterMock, counterMock, timerMock);
        characterMock.IsGrounded.Returns(false);
        counterMock.Current.Returns(1);
        counterMock.When(x => x.Decrement()).Do( x => jumpsCount--);
        longJump.BaseJump();

        Assert.AreEqual(0, jumpsCount);
    }

    [Test]
    public void AdditinalJump_WhenJumpContinueAndJumpDurationMoreThan0_TimerSubstracts()
    {
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();
        var timerValue = 1f;

        longJump.Inittialize(characterMock, counterMock, timerMock);
        characterMock.IsGrounded.Returns(true);
        longJump.BaseJump();
        timerMock.Current.Returns(1);
        timerMock.When(x => x.Substract(Arg.Any<float>())).Do(x => timerValue -= 1f);
        longJump.AdditionalJump();

        Assert.AreEqual(0f, timerValue);
    }

    [Test]
    public void AdditinalJump_WhenJumpContinueAndJumpDurationIsEqual0_TimerReset()
    {
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();
        var timerCurrentValue = 0f;
        var timerStartValue = 1f;

        longJump.Inittialize(characterMock, counterMock, timerMock);
        characterMock.IsGrounded.Returns(true);
        longJump.BaseJump();
        timerMock.Current.Returns(0);
        timerMock.When(x => x.Reset()).Do( x => timerCurrentValue = timerStartValue);
        longJump.AdditionalJump();

        Assert.AreEqual(timerStartValue, timerCurrentValue);
    }

    [Test]
    public void AdditionalJump_WhenJumpDontContinue_TimerDontInvokeSubstract()
    {
        var counterMock = Substitute.For<ICounter>();
        var timerMock = Substitute.For<ITimer>();
        var characterMock = Substitute.For<ICharacter>();
        var longJump = CreateLongJump();
        var timerValue = 1f;

        longJump.Inittialize(characterMock, counterMock, timerMock);
        timerMock.When(x => x.Substract(Arg.Any<float>())).Do(x => timerValue -= 1f);
        longJump.AdditionalJump();

        Assert.AreEqual(1f, timerValue);
    }
}
