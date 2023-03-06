mergeInto(LibraryManager.library, {

  Hello: function () {
    console.log("Hello, world!"); //вызывается всплывающее сообщение
    console.log("Hello world");
  },

   GiveMeUserInfo: function () {

 myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
 
    myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));

    window.alert(player.getName()); 
    console.log(player.getPhoto("medium"));
  
  },

});