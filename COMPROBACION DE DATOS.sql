


-- Información sobre las columnas 'fecha_inicio' y 'fecha_prometido'
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    NUMERIC_PRECISION,
    NUMERIC_SCALE,
    IS_NULLABLE
FROM 
    INFORMATION_SCHEMA.COLUMNS
WHERE 
    TABLE_NAME = 'Ordenes'
    AND TABLE_SCHEMA = 'dbo' -- Cambia 'dbo' si tu esquema es diferente
    AND COLUMN_NAME IN ('fecha_inicio', 'fecha_prometido');

