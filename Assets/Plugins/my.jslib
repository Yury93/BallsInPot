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

     ShowAdv: function () {
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          // some action after close
          console.log("-----SHOW ADV------")
          myGameInstance.SendMessage('PanelResult', 'CloseAdvBetweenScenes')
        },
        onError: function(error) {
          // some action on error
        }
    }
})
  },

});