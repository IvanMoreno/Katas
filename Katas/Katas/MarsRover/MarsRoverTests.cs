using FluentAssertions;
using static Katas.MarsRoverKata.Commands;
using static Katas.MarsRoverKata.MarsRover;

namespace Katas.MarsRoverKata;

// [x] Mover Rover hacia la dirección a la que mira
// [x] Girar Rover
// [] Dar la vuelta a la cuadrícula
// [] Detectar obstáculo
//   [] Informar de encontrarse el obstáculo

public class MarsRoverTests
{
    [Test]
    public void MoveForward()
    {
        new MarsRover().Execute(MoveCommand).Should().Be("0:1:N");
    }

    [Test]
    public void MoveForwardTwice()
    {
        new MarsRover().Execute(MoveCommand + MoveCommand).Should().Be("0:2:N");
    }

    [Test]
    public void KeepPositionStateBetweenMovementCommands()
    {
        var sut = new MarsRover();

        sut.Execute(MoveCommand);
        
        sut.Execute(MoveCommand).Should().Be("0:2:N");
    }

    [Test]
    public void Rotate()
    {
        new MarsRover().Execute("R").Should().Be("0:0:E");
        new MarsRover().Execute("L").Should().Be("0:0:W");
        new MarsRover().Execute("LL").Should().Be("0:0:S");
        new MarsRover().Execute("LLL").Should().Be("0:0:E");
        new MarsRover().Execute("LLLL").Should().Be("0:0:N");
        new MarsRover().Execute("RR").Should().Be("0:0:S");
        new MarsRover().Execute("RRR").Should().Be("0:0:W");
        new MarsRover().Execute("RRRR").Should().Be("0:0:N");
    }

    [Test]
    public void KeepOrientationStateBetweenCommands()
    {
        var sut = new MarsRover();

        sut.Execute("L");

        sut.Execute("L").Should().Be("0:0:S");
    }

    [Test]
    public void MoveTowardsFacingDirection()
    {
        var sut = new MarsRover();

        sut.Execute("R");

        sut.Execute("M").Should().Be("1:0:E");
    }

    [Test]
    public void MixMovementAndRotationCommands()
    {
        new MarsRover().Execute("RM").Should().Be("1:0:E");
    }

    [Test]
    public void LandRoverAtDifferentPosition()
    {
        MarsRover.LandedAt(4, 4).Execute(MoveCommand).Should().Be("4:5:N");
    }

    [Test]
    public void MoveToTheSouth()
    {
        MarsRover.LandedAt(1,1).Execute("RRM").Should().Be("1:0:S");
    }

    [Test]
    public void MoveToTheWest()
    {
        MarsRover.LandedAt(1, 1).Execute(TurnLeft().ThenMove()).Should().Be("0:1:W");
    }

    [Test]
    public void KnowNextMovementDirection()
    {
        var sut = Compass.FacingNorth();
        sut.DirectionX.Should().Be(0);
        sut.DirectionY.Should().Be(1);
    }

    [Test]
    public void OrientationAffectsNextStep()
    {
        var sut = Compass.FacingNorth();
        sut.RotateRight();
        sut.DirectionX.Should().Be(1);
        sut.DirectionY.Should().Be(0);
    }

    [Test]
    public void TurnAroundWhenReachingPositiveEdge()
    {
        new MarsRover().Execute(Move(times:11)).Should().Be("0:0:N");
        new MarsRover().Execute(TurnRight().ThenMove(times:11)).Should().Be("0:0:E");
    }

    [Test]
    public void TurnAroundWhenReachingNegativeEdge()
    {
        new MarsRover().Execute(TurnLeft().ThenMove()).Should().Be("10:0:W");
        new MarsRover().Execute(TurnLeft(2).ThenMove()).Should().Be("0:10:S");
    }

    [Test]
    public void TurnAroundPlateau()
    {
        Plateau.A10x10().NextX(from: 0, towards: 1).Should().Be(1);
        Plateau.A10x10().NextX(from: 1, towards: -1).Should().Be(0);
        Plateau.A10x10().NextX(from: 10, towards: 1).Should().Be(0);
        Plateau.A10x10().NextX(from: 0, towards: -1).Should().Be(10);
        
        Plateau.A10x10().NextY(from: 0, towards: 1).Should().Be(1);
        Plateau.A10x10().NextY(from: 1, towards: -1).Should().Be(0);
        Plateau.A10x10().NextY(from: 10, towards: 1).Should().Be(0);
        Plateau.A10x10().NextY(from: 0, towards: -1).Should().Be(10);
    }
}