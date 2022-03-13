# Quests

A quest is made of

- the data: a scriptable object
- an handler: handle the progress of the quest
- a reward?

As a reminder, a scriptable object "can't" be modified, so we can't track the progress inside.

## Data

The programmer should define the rewards, the attributes of the quest, the name of the quest, and the handler. This is indented to be read by the handler, in order to code the quest.

## Handler

The core of the quest. Use the readonly values in "data" to code the quest.