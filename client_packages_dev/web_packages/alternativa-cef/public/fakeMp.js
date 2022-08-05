const mp = {
    isFake: true,

    trigger: (eventName) => {
        console.warn(`[fakeMp] Triggering event ${eventName}`);
    }
}
