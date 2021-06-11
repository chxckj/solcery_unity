mergeInto(LibraryManager.library, {
    LogToConsole: function (message) {
      ReactUnityWebGL.LogToConsole(Pointer_stringify(message));
    },
    OpenLinkInNewTab: function (link) {
      ReactUnityWebGL.OpenLinkInNewTab(Pointer_stringify(link));
    },
    CreateCard: function (card) {
      ReactUnityWebGL.CreateCard(Pointer_stringify(card));
    },
    UseCard: function (card) {
      ReactUnityWebGL.UseCard(Pointer_stringify(card));
    },
    CreateFight: function () {
      ReactUnityWebGL.CreateFight();
    },
    OnUnityLoaded: function () {
      ReactUnityWebGL.OnUnityLoaded();
    },
  });