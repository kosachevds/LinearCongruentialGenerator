from os import path
from matplotlib import pyplot as pp


def main():
    current_dir = path.dirname(__file__)
    values_filename = path.join(current_dir, "values.txt")
    print("Reading...")
    with open(values_filename, "rt") as values_file:
        values_text = values_file.read()
    print("Converting...")
    values = [int(chunk) for chunk in values_text.split(",")
              if chunk and chunk != "\n"]
    print("Plotting...")
    pp.hist(x=values)
    pp.show()


if __name__ == "__main__":
    main()
