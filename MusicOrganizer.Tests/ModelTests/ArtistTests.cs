using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class ArtistTests : IDisposable
  {
    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("test artist");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      //Act
      string result = newArtist.Name;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      //Act
      string updatedName = "Updated Name";
      newArtist.Name = updatedName;
      string result = newArtist.Name;

      //Assert
      Assert.AreEqual(updatedName, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ArtistList()
    {
      // Arrange
      List<Artist> newList = new List<Artist> { };

      // Act
      List<Artist> result = Artist.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsArtists_ArtistList()
    {
      //Arrange
      string name01 = "Walk the dog";
      string name02 = "Wash the dishes";
      Artist newArtist1 = new Artist(name01);
      Artist newArtist2 = new Artist(name02);
      List<Artist> newList = new List<Artist> { newArtist1, newArtist2 };

      //Act
      List<Artist> result = Artist.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}