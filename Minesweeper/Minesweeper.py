import random
from time import sleep


def Difficulty():
    difficulty = int(input("Select your difficulty level from the following:\n"
                           "1. Beginner: 5x5 Grid - Contains 3 Bombs!\n"
                           "2. Intermediate: 6x6 Grid - Contains 8 Bombs!\n"
                           "3. Expert: 8x8 Grid - Contains 20 Bombs!\n"
                           "\nChoose between 1 and 3: "))
    if difficulty == 1:
        size = 5
        bombs = 3
        win = 21
    elif difficulty == 2:
        size = 6
        bombs = 8
        win = 27
    elif difficulty == 3:
        size = 8
        bombs = 20
        win = 43

    return win, size, bombs


def GenerateMinedMap(size, bombs):
    grid = [[0 for row in range(size)] for column in range(size)]
    start = 0
    BombLocations = ""
    while start < bombs:
        x = random.randint(0, size - 1)
        y = random.randint(0, size - 1)
        Axis = str(x+1) + "," + str(y+1)
        if Axis in BombLocations:
            start += 1
            bombs += 1
        else:
            BombLocations += "[" + Axis + "]"
            grid[y][x] = '💣'
            if x >= 0 and x <= size - 2 and y >= 0 and y <= size - 1:
                if grid[y][x + 1] != '💣':
                    grid[y][x + 1] += 1

            if x >= 1 and x <= size - 1 and y >= 0 and y <= size - 1:
                if grid[y][x - 1] != '💣':
                    grid[y][x - 1] += 1

            if x >= 1 and x <= size - 1 and y >= 1 and y <= size - 1:
                if grid[y - 1][x - 1] != '💣':
                    grid[y - 1][x - 1] += 1

            if x >= 0 and x <= size - 2 and y >= 1 and y <= size - 1:
                if grid[y - 1][x + 1] != '💣':
                    grid[y - 1][x + 1] += 1

            if x >= 0 and x <= size - 1 and y >= 1 and y <= size - 1:
                if grid[y - 1][x] != '💣':
                    grid[y - 1][x] += 1

            if x >= 0 and x <= size - 2 and y >= 0 and y <= size - 2:
                if grid[y + 1][x + 1] != '💣':
                    grid[y + 1][x + 1] += 1

            if x >= 1 and x <= size - 1 and y >= 0 and y <= size - 2:
                if grid[y + 1][x - 1] != '💣':
                    grid[y + 1][x - 1] += 1

            if x >= 0 and x <= size - 1 and y >= 0 and y <= size - 2:
                if grid[y + 1][x] != '💣':
                    grid[y + 1][x] += 1
            start += 1

    return grid


def GeneratePlayerMapView(size):
    grid = [['□' for row in range(size)] for column in range(size)]
    return grid


def DisplayMap(map):
    print()
    for row in map:
        print(" ".join(str(box) for box in row))


def Instructions():
    print("Instructions\n"
          "1. No faulty inputs allowed.\n"
          "2. Use the joystick to restart/reset the game\n"
          "3. Use the green button as a yes\n"
          "4. Use the red button as a no.\n"
          "5. Use the yellow button to press enter.\n"
          "6. The speaker, LED circuit and I2C LCD will let you know how you are performing throughout the game.\n"
          "7. The character/matrix pad is only to be used when you are asked to save your score.\n")
    return


def CheckContinueGame():
    Continue = input("\nWould you like to play again? (Y/N): ")
    print()
    if Continue.upper() != "Y":
        print("Thanks for playing\n"
              "Goodbye")
        sleep(5)
        exit()
    else:
        status = True
    return status


def Play():
    print("Welcome to Minesweeper")
    while True:
        ReadInstructions = input("Would you like to read the instructions? (Y/N): ")
        print()
        if ReadInstructions.upper() == "Y":
            Instructions()
            sleep(15)
        elif ReadInstructions.upper() != "N" and ReadInstructions.upper() != "Y":
            exit()
        else:
            difficulty = Difficulty()
            MinesweeperMap = GenerateMinedMap(difficulty[1], difficulty[2])
            PlayerMap = GeneratePlayerMapView(difficulty[1])
            BoxesCount = 0
            DisplayMap(PlayerMap)
            BoxesOpened = ""
            while True:
                print("\nTake a look at the grid above and decide which box you would like to open")
                x = int(input("Row (Horizontal) (1 to " + str(difficulty[1]) + "): "))
                y = int(input("Column (Vertical) (1 to " + str(difficulty[1]) + "): "))
                if x < 1 or x > difficulty[1] and y < 1 or y > difficulty[1]:
                    exit()
                else:
                    x = x - 1
                    y = y - 1
                    Box = str(x+1) + "," + str(y+1)
                    if Box in BoxesOpened:
                        print("\nYou already entered this location [" + Box + "]")
                        DisplayMap(PlayerMap)
                    elif MinesweeperMap[y][x] != '💣' and BoxesCount < difficulty[0]:
                        PlayerMap[y][x] = MinesweeperMap[y][x]
                        DisplayMap(PlayerMap)
                        BoxesOpened += "[" + Box + "]"
                        BoxesCount += 1
                    elif MinesweeperMap[y][x] == '💣':
                        DisplayMap(MinesweeperMap)
                        print("\nYou Lost")
                        CheckContinueGame()
                        break
                    elif BoxesCount == difficulty[0]:
                        DisplayMap(MinesweeperMap)
                        print("\nCongratulations You Win!")
                        CheckContinueGame()
                        break


Play()



