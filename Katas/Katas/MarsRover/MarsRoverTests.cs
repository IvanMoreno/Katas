using FluentAssertions;

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
        new MarsRover().Execute("M").Should().Be("0:1:N");
    }
}