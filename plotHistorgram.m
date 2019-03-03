fileId = fopen('./values.txt', 'rt');
values = fscanf(fileId, '%f;');
fclose(fileId);
valuesCount = length(values);
binsCount = min([valuesCount, 100]);
hist(values, binsCount);
disp(['Mean = ', num2str(mean(values))]);
disp(['Std  = ', num2str(std(values))]);