using FluentAssertions;
using static Katas.MarsRoverKata.MarsRover;

namespace Katas.MarsRoverKata;

// [] Mover Rover hacia la dirección a la que mira
// [] Girar Rover
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
}