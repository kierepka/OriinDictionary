import 'dart:async';

class _EventData<T> {
  Object sender;
  T data;

  _EventData(this.sender, this.data);
}

typedef void EventHandler<T>(Object sender, T data);

class Event<T> {
  final _streamController =
      new StreamController<_EventData<T>>.broadcast(sync: true);
  final _listeners = new Map<Object, StreamSubscription<_EventData<T>>>();
  final _eventHandlers = new Map<Object, EventHandler<T>>();

  void addListener(Object owner, EventHandler<T> eventHandler) {
    _eventHandlers[owner] = eventHandler;
    var listener = _streamController.stream.listen(_onData);
    _listeners[owner] = listener;
  }

  void removeListener(Object owner) {
    if (_listeners.containsKey(owner)) {
      var listener = _listeners[owner];
      listener.cancel();
      _listeners.remove(owner);
    }
    _eventHandlers.remove(owner);
  }

  void emit(Object sender, T val) {
    var data = new _EventData(sender, val);
    _streamController.add(data);
  }

  void _onData(_EventData<T> eventData) {
    final owner = eventData.sender;
    if (_eventHandlers.containsKey(owner)) {
      final eventHandler = _eventHandlers[owner];
      final data = eventData.data;
      eventHandler(owner, data);
    }
  }
}
