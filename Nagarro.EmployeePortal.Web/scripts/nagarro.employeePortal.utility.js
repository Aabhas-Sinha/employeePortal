/**
 * Created by anshulparmar on 07/18/2015.
 */
function utility() {
    this.attachEvent = function (outerSelector, eventName, innerSelector, callback) {
        $(outerSelector).off(eventName, innerSelector);
        $(outerSelector).on(eventName, innerSelector, callback);
    };
};
