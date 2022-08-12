window.altListeners = new Map()

const mp = {
    isFake: true,

    trigger: (eventName) => {
        console.warn(`[fakeMp] Triggering event ${eventName}`);
    },

    call(eventString, data) {
        const eventListeners = window.altListeners.get(eventString)
        if (!eventListeners || eventListeners.length === 0) console.error(`[fakeMp] No listeners for event '${eventString}'`)
        else eventListeners.forEach(listener => listener(data))
    }
}
